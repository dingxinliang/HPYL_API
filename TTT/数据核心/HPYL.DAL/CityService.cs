#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.DAL
* 项目描述 ：
* 类 名 称 ：CityService
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.DAL
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/31 13:47:37
* 更新时间 ：2018/8/31 13:47:37
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using Himall.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace HPYL.DAL
{
    public class RegionService { 

        private IEnumerable<Region> regions;
        private  string REGION_FILE_PATH = ConfigurationManager.AppSettings["regionpath"];
        private  string REGION_BAK_PATH = ConfigurationManager.AppSettings["regionbakpath"];


        private string GetPhysicalPath(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                if (fileName.StartsWith("http://") || fileName.StartsWith("https://"))
                    fileName = fileName.Substring(fileName.IndexOf("/", fileName.IndexOf("//") + 2) + 1);

                var index = fileName.LastIndexOf("@");
                if (index > 0)
                    fileName = fileName.Substring(0, index);
            }

            return Himall.Core.Helper.IOHelper.GetMapPath(fileName);
        }


    
        public byte[] GetFileContent(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }
            var f = GetPhysicalPath(fileName);
            FileStream fs = new FileStream(f, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }
        /// <summary>
        /// 横向平铺的地区数据
        /// </summary>
        private IEnumerable<Region> RegionSource
        {
            get
            {
                if (regions == null)
                {
                  regions = LoadRegionData();
                }
                return regions;
            }
        }



        /// <summary>
        /// 从JS加载地区数据
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Region> LoadRegionData()
        {
            IEnumerable<Region> region;
            // string regionString = string.Empty;
            //using (FileStream fs = new FileStream(Core.Helper.IOHelper.GetMapPath("/Scripts/Region.json"), FileMode.Open))
            //{
            //    using (StreamReader streamReader = new StreamReader(fs))
            //    {
            //        regionString = streamReader.ReadToEnd();
            //    }
            //}

            var regionBytes =GetFileContent(REGION_FILE_PATH);
            var regionString = System.Text.Encoding.UTF8.GetString(regionBytes);
            List<Region> source = new List<Region>();
            region = JsonConvert.DeserializeObject<IEnumerable<Region>>(regionString);
            foreach (var item in region)
            {
                FillRegion(source, item, 1);
            }
            return source;
        }

        /// <summary>
        /// 把子地区平铺
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parent"></param>
        /// <param name="level"></param>
        private void FillRegion(List<Region> list, Region parent, int level)
        {
            list.Add(parent);
            parent.Level = (Region.RegionLevel)level;
            level++;
            if (parent.Sub == null)
                return;
            if (level > 4) { parent.Sub = null; return; }//清空等级大于4的行政区域

            foreach (var sub in parent.Sub)
            {
                sub.Parent = parent;
                FillRegion(list, sub, level);
            }
        }

        /// <summary>
        /// 检查同名区域
        /// </summary>
        /// <param name="regionName"></param>
        /// <param name="region"></param>
        private void CheckRegionName(string regionName, List<Region> region)
        {
            if (region.Any(a => a.Name == regionName || a.ShortName == regionName))
            {
                throw new HimallException("已存在相同区域名称");
            }
        }


    

   


   
        /// <summary>
        /// 获取横向平铺的地区数据
        /// </summary>
        public IEnumerable<Region> GetAllRegions()
        {
            return RegionSource;
        }

     

        /// <summary>
        /// 根据ID获取某个地区的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Region GetRegion(long id)
        {
            return RegionSource.FirstOrDefault(p => p.Id == id);
        }

        public Region GetRegion(long id, Region.RegionLevel level)
        {
            var region = RegionSource.FirstOrDefault(p => p.Id == id);
            while (region != null && region.Level > level)
            {
                region = region.Parent;
            }
            if (region != null && region.Level == level)
                return region;
            return null;
        }

        public Region GetRegionByName(string name)
        {
            return RegionSource.FirstOrDefault(p => p.Name.Contains(name) || name.Contains(p.Name));
        }

        public Region GetRegionByName(string name, Region.RegionLevel level)
        {
            return RegionSource.FirstOrDefault(p => (p.Name.Contains(name) || name.Contains(p.Name)) && p.Level == level);
        }

        public IEnumerable<Region> GetSubs(long parent, bool trace = false)
        {
            if (parent == 0)
                return RegionSource.Where(p => p.ParentId == 0);

            var region = RegionSource.FirstOrDefault(p => p.Id == parent);
            if (trace)
            {
                List<Region> sub = new List<Region>();
                FillSubRegion(sub, region);
                return sub;
            }
            return region.Sub ?? new List<Region>();//下属区域
        }


        /// <summary>
        /// 获取三级子类
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public IEnumerable<Region> GetThridSubs(long parent)
        {
            if (parent == 0)
                return RegionSource.Where(p => p.ParentId == 0);

            var region = RegionSource.FirstOrDefault(p => p.Id == parent);
            List<Region> sub = new List<Region>();
            FillSubRegion(sub, region, Region.RegionLevel.County);
            return sub;
        }



        /// <summary>
        /// 填充追溯所有下属子集
        /// </summary>
        /// <param name="list">填充列表</param>
        /// <param name="model"></param>
        private void FillSubRegion(List<Region> list, Region model, Region.RegionLevel level = Region.RegionLevel.Village)
        {
            if (model.Sub == null || model.Sub.Count == 0 || model.Level == level)
                return;
            foreach (var item in model.Sub)//市级
            {
                if (item.Sub != null && item.Sub.Count > 0 && item.Level != level)
                {
                    list.AddRange(item.Sub);
                    FillSubRegion(list, item, level);
                }
                else
                {
                    item.Sub = new List<Region>();
                }
            }
        }

        public string GetFullName(long id, string seperator = " ")
        {
            var region = RegionSource.FirstOrDefault(p => p.Id == id);
            if (region == null)
                return string.Empty;
            var name = region.Name;
            //追溯上级区域,最多追溯5次 防循环溢出
            for (int i = 0; i < 5 && region.Parent != null; i++)
            {
                region = region.Parent;
                name = region.Name + seperator + name;
            }
            return name;
        }

        public string GetRegionPath(long id, string seperator = ",")
        {
            var region = RegionSource.FirstOrDefault(p => p.Id == id);
            if (region == null)
                return string.Empty;
            var path = id.ToString();

            //追溯上级区域,最多追溯5次 防循环溢出
            for (int i = 0; i < 5 && region.Parent != null; i++)
            {
                region = region.Parent;
                path = region.Id + "," + path;
            }
            return path;
        }
        /// <summary>
        /// 根据地址名称反查地址全路径
        /// </summary>
        /// <param name="city">城市名</param>
        /// <param name="district">区名</param>
        /// <param name="street">街道名</param>
        /// <returns></returns>
        public string GetAddress_Components(string city, string district, string street, out string newStreet)
        {
            Region myregion = null;
            var cityData = RegionSource.FirstOrDefault(p => p.Name == city.Trim() && p.Level == Region.RegionLevel.City);//城市
            if (cityData != null)
            {
                var parent = RegionSource.FirstOrDefault(p => p.Name == district.Trim() && p.Level == Region.RegionLevel.County && p.ParentId == cityData.Id);//区域
                if (parent != null)
                {
                    myregion = RegionSource.Where(p => p.Name == street.Trim() && p.ParentId == (parent.Id)).FirstOrDefault();//优先街道
                    if (myregion == null)
                    {
                        street = street.Replace("街道", "").Replace("镇", "").Replace("街", "");//地区库第四级可能不包含“街道、镇等文字”
                        myregion = RegionSource.Where(p => p.Name == street.Trim() && p.ParentId == (parent.Id)).FirstOrDefault();//特殊替换处理
                    }
                }
                if (myregion == null && parent != null)//街空取区
                {
                    myregion = parent;
                }
            }

            newStreet = street;

            if (myregion == null)
                return string.Empty;


            var path = myregion.Id.ToString();
            //追溯上级区域,最多追溯5次 防循环溢出
            for (int i = 0; i < 5 && myregion.Parent != null; i++)
            {
                myregion = myregion.Parent;
                path = myregion.Id + "," + path;
            }
            return path;
        }
   

        #region 私有方法

        /// <summary>
        /// 获取短地址   
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetShortAddressName(string str)
        {
            string result = str;
            result = result.Replace("特别行政区", "");
            result = result.Replace("省", "");
            result = result.Replace("维吾尔", "");
            result = result.Replace("回族", "");
            result = result.Replace("壮族", "");
            result = result.Replace("自治区", "");
            result = result.Replace("市", "");
            result = result.Replace("盟", "");
            result = result.Replace("林区", "");
            result = result.Replace("地区", "");
            result = result.Replace("土家族", "");
            result = result.Replace("苗族", "");
            result = result.Replace("回族", "");
            result = result.Replace("黎族", "");
            result = result.Replace("藏族", "");
            result = result.Replace("傣族", "");
            result = result.Replace("彝族", "");
            result = result.Replace("哈尼族", "");
            result = result.Replace("壮族", "");
            result = result.Replace("白族", "");
            result = result.Replace("景颇族", "");
            result = result.Replace("傈僳族", "");
            result = result.Replace("朝鲜族", "");
            result = result.Replace("蒙古", "");
            result = result.Replace("哈萨克", "");
            result = result.Replace("柯尔克孜", "");
            result = result.Replace("自治州", "");
            result = result.Replace("自治县", "");
            result = result.Replace("县", "");
            return result;
        }
        private void SetSub(Region topRegion, string regionName, int Id, string shortName)
        {
            var sub = topRegion.Sub;
            if (sub == null)
            {
                sub = new List<Region>();
                sub.Add(new Region() { Name = regionName, Id = Id, ShortName = GetShortAddressName(regionName) });
                topRegion.Sub = sub;
            }
            else
            {
                CheckRegionName(regionName, sub);
                sub.Add(new Region() { Name = regionName, Id = Id, ShortName = GetShortAddressName(regionName) });
            }
        }

        #endregion
    }
    public class Region
    {
        /// <summary>
        /// 区域编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 区域简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 下属区域
        /// </summary>

        //[ScriptIgnore]//使用JavaScriptSerializer序列化时不序列化此字段
        //[IgnoreDataMember]//使用DataContractJsonSerializer序列化时不序列化此字段
        //[Newtonsoft.Json.JsonIgnore]//使用JsonConvert序列化时不序列化此字段
        public List<Region> Sub { get; set; }

        /// <summary>
        /// 上属区域
        /// </summary>
        [ScriptIgnore]//使用JavaScriptSerializer序列化时不序列化此字段
        [IgnoreDataMember]//使用DataContractJsonSerializer序列化时不序列化此字段
        [Newtonsoft.Json.JsonIgnore]//使用JsonConvert序列化时不序列化此字段
        public Region Parent { get; set; }

        /// <summary>
        /// 上属区域编号
        /// </summary>
        [ScriptIgnore]//使用JavaScriptSerializer序列化时不序列化此字段
        [IgnoreDataMember]//使用DataContractJsonSerializer序列化时不序列化此字段
        [Newtonsoft.Json.JsonIgnore]//使用JsonConvert序列化时不序列化此字段
        public int ParentId
        {
            get
            {
                if (Parent == null)
                    return 0;
                else
                    return Parent.Id;
            }
        }

        /// <summary>
        /// 区域行政等级
        /// </summary>
        [ScriptIgnore]//使用JavaScriptSerializer序列化时不序列化此字段
        [IgnoreDataMember]//使用DataContractJsonSerializer序列化时不序列化此字段
        [Newtonsoft.Json.JsonIgnore]//使用JsonConvert序列化时不序列化此字段
        public RegionLevel Level { get; set; }

        /// <summary>
        /// 区域行政等级
        /// </summary>
        public enum RegionLevel : int
        {
            /// <summary>
            /// 省级
            /// </summary>
            Province = 1,
            /// <summary>
            /// 市级
            /// </summary>
            City = 2,
            /// <summary>
            /// 区级
            /// </summary>
            County = 3,
            /// <summary>
            /// 镇级
            /// </summary>
            Town = 4,
            /// <summary>
            /// 村级
            /// </summary>
            Village = 5,
        }

        /// <summary>
        /// 获取当前区域到最上级的名称串
        /// </summary>
        /// <param name="split">名称之前的分隔符，默认为空格</param>
        /// <returns></returns>
        public string GetNamePath(string split = " ")
        {
            if (Parent != null)
                return string.Format("{0}{1}{2}", Parent.GetNamePath(), split, Name);
            return Name;
        }

        /// <summary>
        /// 获取当前区域到最上级的id串
        /// </summary>
        /// <param name="split">名称之前的分隔符，默认为逗号</param>
        /// <returns></returns>
        public string GetIdPath(string split = ",")
        {
            if (Parent != null)
                return string.Format("{0}{1}{2}", Parent.GetIdPath(), split, Id);
            return Id.ToString();
        }
    }

}
