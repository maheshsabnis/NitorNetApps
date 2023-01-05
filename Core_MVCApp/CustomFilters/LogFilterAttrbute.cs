using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Core_MVCApp.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private void LogRequest(string currentStatus, RouteData routeData)
        {
            string controllerName = routeData.Values["controller"].ToString();
            string actionName = routeData.Values["action"].ToString();
            string logMessage = $"Current Status of Request is {currentStatus} in {actionName} Action Method of {controllerName} contrller";

            // Log on Output windows
            Debug.WriteLine(logMessage);
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogRequest("OnActionExecuting", filterContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogRequest("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogRequest("OnResultExecuting", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogRequest("OnResultExecuted", filterContext.RouteData);
        }
    }
}
