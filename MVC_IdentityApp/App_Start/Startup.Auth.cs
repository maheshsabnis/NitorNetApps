using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using MVC_IdentityApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace MVC_IdentityApp
{
    public partial class Startup
    {

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);


            #region Logic to CReate a Adminstrator ROle and Admin USer

           
            

            ApplicationDbContext dbContext = new ApplicationDbContext();

            // 1. Check if Administrator Role Exist
            var adminRole = dbContext.Roles.Where(r=>r.Name == "Administrator").FirstOrDefault();
            if (adminRole == null)
            {
                dbContext.Roles.Add(new IdentityRole() { Name = "Administrator" });
                dbContext.SaveChanges();

               
            }

            // 2. Check the admin@myapp.com user
            var adminUser = dbContext.Users.Where(u => u.UserName == "admin@myapp.com").FirstOrDefault();
            if (adminUser == null)
            {
                // 2.a. Create USer
                IdentityUser identityUser = new IdentityUser()
                {
                    Email = "admin@myapp.com",
                    UserName= "admin@myapp.com",
                    PasswordHash =   "ADMaNA4eg6s+c6iuZn4ZVqyePrDBzir7rvZwyvJqyLsN6BIP/HHaL4UzSd6FiZZNzg==" 
                };

                ApplicationUser applicationUser = new ApplicationUser() 
                {
                    Email = "admin@myapp.com",
                    UserName = "admin@myapp.com",
                   // PasswordHash = "P@ssw0rd_"
                };
                

                //dbContext.Users.Add(applicationUser);
                //dbContext.SaveChanges();

                //var theuser = dbContext.Users.Where(u => u.UserName == "admin@myapp.com").FirstOrDefault();

            
                ApplicationUserManager user = new ApplicationUserManager(new ApplicationUserStore(dbContext));

                user.Create(applicationUser, "P@ssw0rd_");


                var theuser = dbContext.Users.Where(u => u.UserName == "admin@myapp.com").FirstOrDefault();
                user.AddToRole(theuser.Id, "Administrator");




            }


            #endregion




            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }

    // MEchanism to connect to the user Info Store
    public interface IUserStore : IUserStore<ApplicationUser> { }

    public class ApplicationUserStore : UserStore<ApplicationUser>, IUserStore {
    public ApplicationUserStore(ApplicationDbContext dbContext)
        : base(dbContext) { }
}
}