using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_IdentityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_IdentityApp.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context= new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {
            var roles  =context.Roles;
            return View(roles);
        }

        public ActionResult Create() 
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
