using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_IdentityApp.Startup))]
namespace MVC_IdentityApp
{
    public partial class Startup
    {/// <summary>
     /// IAppBuilder: AN iNterface that is used to 
     /// Build all required objects for Identity Management in HTTP Request Pipeline
     /// </summary>
     /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
