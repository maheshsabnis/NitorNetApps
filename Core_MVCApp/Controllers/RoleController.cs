using Core_MVCApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVCApp.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<IdentityUser> userManager;
        /// <summary>
        /// Inject the ROle Manager
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            var result = await roleManager.CreateAsync(role);   
            if (result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        public IActionResult AssignRoleToUser()
        {
            var users = new List<SelectListItem>();
            var roles = new List<SelectListItem>();
            foreach (var user in userManager.Users.ToList())
            {
                // Add USers from USerManager to SelectListItem
                //                          DataTetx,   DataValue
                users.Add(new SelectListItem(user.UserName,user.Id));
            }

            foreach (var role in roleManager.Roles.ToList())
            {
                roles.Add(new SelectListItem(role.Name, role.Id));
            }

            ViewBag.UserId = users;
            ViewBag.RoleId = roles;
            return View(new UserRole());
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(UserRole userRole)
        {
            // Get the USer From Id
            var userObj = await userManager.FindByIdAsync(userRole.UserId);
            // Get the Role From Id
            var roleObj = await roleManager.FindByIdAsync(userRole.RoleId);

            /// MAke Sure that write code for checking User and Role Exists

            await userManager.AddToRoleAsync(userObj, roleObj.Name);


            var users = new List<SelectListItem>();
            var roles = new List<SelectListItem>();
            foreach (var user in userManager.Users.ToList())
            {
                // Add USers from USerManager to SelectListItem
                //                          DataTetx,   DataValue
                users.Add(new SelectListItem(user.UserName, user.Id));
            }

            foreach (var role in roleManager.Roles.ToList())
            {
                roles.Add(new SelectListItem(role.Name, role.Id));
            }

            ViewBag.UserId = users;
            ViewBag.RoleId = roles;
            return RedirectToAction("Index");   
        }
    }
}
