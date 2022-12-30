using Application.DataAccess.DataAccess;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MVC_Application
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // Register the Depednency Class
            // 1. INteraceNAme,Class Name
            // 2. Only CLass
            // REgistering DepartmentDataAccess as a 
            // Scopped Object (One object for each new Session)
           container.RegisterType<DepartmentDataAccess>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}