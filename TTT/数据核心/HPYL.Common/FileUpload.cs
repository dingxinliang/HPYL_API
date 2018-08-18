using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;
using System.Drawing;

namespace HPYL.Common
{
    public class FileUpload
    {
        public static void UploadRealIdentity(out string IDFrontPic, out string IDBackPic)
        {
            //SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            //sArray.Add("UserId", UserId);
            //sArray.Add("IDCard", IDCard);
            //sArray.Add("RealName", RealName);
            //sArray.Add("Ts", Ts);

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                //for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                //{
                //}
                HttpPostedFile file1 = HttpContext.Current.Request.Files["Filedata1"];
                //正面
                IDFrontPic = Upload(file1);
                HttpPostedFile file2 = HttpContext.Current.Request.Files["Filedata2"];
                //反面
                IDBackPic = Upload(file2);

            }
            else
            {
                IDFrontPic = string.Empty;
                IDBackPic = string.Empty;
            }

        }

        public static string Upload(HttpPostedFile postedFile)
        {
            if (postedFile != null && postedFile.FileName.Length > 0)
            {
                string FExtension = System.IO.Path.GetExtension(postedFile.FileName);
                if (checkExtensionName(FExtension))
                {
                    string saveFolder = "/Upload/IdCard/";
                    string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    string path = HttpContext.Current.Server.MapPath(".") + saveFolder;
                    if (!Directory.Exists(path))
                    {
                        // 尝试创建目录
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }

                    postedFile.SaveAs(path + newFileName + FExtension);//ImageWebUrl
                    return System.Configuration.ConfigurationManager.AppSettings["ImageWebUrl"] + saveFolder + newFileName + FExtension;
                }
            }
            return "";
        }
        public static bool checkExtension(string fileName)
        {
            string FExtension = System.IO.Path.GetExtension(fileName);
            if (FExtension == ".jpg" || FExtension == ".png" || FExtension == ".gif" || FExtension == ".bmp")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool checkExtensionName(string extName)
        {

            if (extName == ".jpg" || extName == ".png" || extName == ".gif" || extName == ".bmp")
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
