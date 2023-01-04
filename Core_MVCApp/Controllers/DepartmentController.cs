using Core_MVCApp.Models;
using Core_MVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVCApp.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            var records = await deptServ.GetAsync();
            return View(records);
        }

        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = await deptServ.Create(dept);
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

        public async Task<IActionResult> Delete(int id)
        {
            var record = await deptServ.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
