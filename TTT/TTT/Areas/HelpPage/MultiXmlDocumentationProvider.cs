using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using  HPYL_API.Areas.HelpPage.ModelDescriptions;

namespace  HPYL_API.Areas.HelpPage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2017-2018 北京佰云信息技术有限公司
    /// 创建人：DXL
    /// 日 期：2017-09-09 16:32:30 
    /// 描 述： 
    /// </summary>
    public class MultiXmlDocumentationProvider : IDocumentationProvider, IModelDocumentationProvider
    {
        /********* 
        ** Properties 
        *********/
        /// <summary>The internal documentation providers for specific files.</summary>  
        private readonly XmlDocumentationProvider[] Providers;


        /********* 
        ** Public methods 
        *********/
        /// <summary>Construct an instance.</summary>  
        /// <param name="paths">The physical paths to the XML documents.</param>  
        public MultiXmlDocumentationProvider(params string[] paths)
        {
            this.Providers = paths.Select(p => new XmlDocumentationProvider(p)).ToArray();
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetDocumentation(MemberInfo subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetDocumentation(Type subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetDocumentation(HttpControllerDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetDocumentation(HttpActionDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetDocumentation(HttpParameterDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>  
        /// <param name="subject">The subject to document.</param>  
        public string GetResponseDocumentation(HttpActionDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }


        /********* 
        ** Private methods 
        *********/
        /// <summary>Get the first valid result from the collection of XML documentation providers.</summary>  
        /// <param name="expr">The method to invoke.</param>  
        private string GetFirstMatch(Func<XmlDocumentationProvider, string> expr)
        {
            return this.Providers
                .Select(expr)
                .FirstOrDefault(p => !String.IsNullOrWhiteSpace(p));
        }
    }
}