using MVC_Application.CustomFilters;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogFilterAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
