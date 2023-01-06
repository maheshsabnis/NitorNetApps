using Core_MVCApp.Models;
using Core_MVCApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core_MVCApp.CustomSessions;
using Core_MVCApp.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace Core_MVCApp.Controllers
{
   // [Authorize]
    public class DepartmentController : Controller
    {
        // Define Service Reference
        IService<Department, int> deptServ;

        /// <summary>
        /// Inject the DepartmentService in the Class
        /// </summary>
        public DepartmentController(IService<Department,int> serv)
        {
            deptServ= serv;
        }

        // [Authorize(Roles = "Manager,Clerk,Operator")]
        [Authorize(Policy ="ReadPolicy")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "Hay!!! I am Secure....";
            var records = await deptServ.GetAsync();
            return View(records);
        }

        //[Authorize(Roles = "Manager,Clerk")]
        [Authorize(Policy = "CreatePolicy")]
        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department dept)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    if (dept.Capacity < 0)
                        throw new Exception("Capacity Cannot be -ve");
                    var record = await deptServ.Create(dept);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(dept);
                }
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new ErrorViewModel() 
            //    {
            //        ControllerName = RouteData.Values["controller"].ToString(),
            //        ActionName = RouteData.Values["action"].ToString(),
            //        ExceptionMessage= ex.Message
            //    });
            //}
        }

        // [Authorize(Roles = "Manager")]
        [Authorize(Policy = "EditDeletePolicy")]
        public async Task<IActionResult> Edit(int id)
        {
            var record = await deptServ.GetAsync(id);
            return View(record);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Department dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = await deptServ.Update(id,dept);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(dept);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // [Authorize(Roles = "Manager")]
        [Authorize(Policy = "EditDeletePolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await deptServ.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            // TO Save CLR object in Session better Serialize it to JSON 

            var dept = await deptServ.GetAsync(id);
            // serialize in JSON
            //  var deptData = JsonSerializer.Serialize(dept);

            // Save in Session
            // HttpContext.Session.SetString("Dept", deptData);

            // USing The Custom Session

            HttpContext.Session.SetCLRObject<Department>("Dept", dept);

            // Save data in Session
            HttpContext.Session.SetInt32("DeptNo", id);
            return RedirectToAction("Index", "Employee");
        }

    }
}
