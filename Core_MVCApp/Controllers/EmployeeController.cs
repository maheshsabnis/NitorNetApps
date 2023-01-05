using Core_MVCApp.Models;
using Core_MVCApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Core_MVCApp.CustomSessions;

namespace Core_MVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        // Define Service Reference
        IService<Employee, int> empServ;

        /// <summary>
        /// Inject the EmployeeService in the Class
        /// </summary>
        public EmployeeController(IService<Employee,int> serv)
        {
            empServ= serv;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> records = null;
            // REad data from Session

            //var deptData = HttpContext.Session.GetString("Dept");

            //var deptObj = JsonSerializer.Deserialize<Department>(deptData);

            var data = HttpContext.Session.GetCLRObject<Department>("Dept");

            var dno = HttpContext.Session.GetInt32("DeptNo");
            if (dno == 0)
            {
                records = await empServ.GetAsync();
            }
            else
            {
                records = (await empServ.GetAsync()).Where(e => e.DeptNo == dno).ToList(); 
            }

            
            return View(records);
        }

        public IActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = await empServ.Create(dept);
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
            var record = await empServ.GetAsync(id);
            return View(record);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var record = await empServ.Update(id,dept);
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
            var record = await empServ.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
