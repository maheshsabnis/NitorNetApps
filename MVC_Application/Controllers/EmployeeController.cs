using Application.DataAccess.DataAccess;
using Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Application.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccess empdataAccess;
        DepartmentDataAccess deptdataAccess;
        public EmployeeController(EmployeeDataAccess empdataAccess, DepartmentDataAccess deptdataAccess)
        {
            this.empdataAccess = empdataAccess;
            this.deptdataAccess = deptdataAccess;
        }


        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> emps = new List<Employee>();

            // REad data from Tempdata
            int deptno = Convert.ToInt32(TempData["DeptNo"]);
            var dept = (Department)TempData["Dept"];
            if (deptno > 0)
            {
                // REad Data of EMployees for teh received DeptNo
                emps = empdataAccess.GetEmployees().Where(e=>e.DeptNo == deptno).ToList();
            }
            else
            {
               emps = empdataAccess.GetEmployees();
            }
            // Keep Data of all Keys from Tempdata
            TempData.Keep();
            return View(emps);
        }

        /// <summary>
        /// HTTP Get Metod for CReating Create View with
        /// EMpty TextBoxes
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var id = TempData["DeptNo"];

            var dept = new Employee();
            // Define a ViewBag that will pass List of Department with DeptNo and DEptNAme to Create view
            ViewBag.DeptNo = new SelectList(deptdataAccess.GetDepartments(), "DeptNo", "DeptName");
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(Employee Employee)
        {
            // First Approach of hadling Exception
            //try
            //{
            // now validate the Employee Model
            if (ModelState.IsValid)
            {
                 
                empdataAccess.CreateEmployee(Employee);
                return RedirectToAction("Index");
            }
            else
            {
                // Stey on Same Page
                ViewBag.DeptNo = new SelectList(deptdataAccess.GetDepartments(), "DeptNo", "DeptName");
                return View(Employee);
            }
            

        }
         

        public ActionResult Edit(int id)
        {
            var dept = empdataAccess.GetEmployees(id);
            return View(dept);
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee Employee)
        {
            empdataAccess.UpdateEmployee(id, Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dept = empdataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}