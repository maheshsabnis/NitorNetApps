using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace Core_MVCApp.CustomFilters
{
    public class CustomExceptionFilterAttribute : IExceptionFilter
    {
        IModelMetadataProvider modelMetadata;
        /// <summary>
        /// Inject the IModelMetadataProvider that will be used to read the
        /// MOdel Class involved in CUrrent Request
        /// This is REsolved by The AddControllerWithViews() method
        /// that is registered in DI Container
        /// </summary>
        /// <param name="modelMetadata"></param>
        public CustomExceptionFilterAttribute(IModelMetadataProvider modelMetadata)
        {
            this.modelMetadata = modelMetadata;
        }
        
        public void OnException(ExceptionContext filterContext)
        {
            // 1. Hadle Exception
            filterContext.ExceptionHandled = true;
            // 2. REad Error MEsssage
            string errorMessage = filterContext.Exception.Message;
            // 3. GO to Error Page
            ViewResult viewResult = new ViewResult();

            viewResult.ViewName= "Error";

            // Define a ViewDataDictionary Object

            ViewDataDictionary vData = new ViewDataDictionary(modelMetadata,filterContext.ModelState);
            // Set the ViewData
            vData["ControllerName"] = filterContext.RouteData.Values["controller"].ToString();
            vData["ActionName"] = filterContext.RouteData.Values["action"].ToString();
            vData["ExceptionMessage"] = errorMessage;

            viewResult.ViewData = vData;

            filterContext.Result  =  viewResult;

        }
    }
}