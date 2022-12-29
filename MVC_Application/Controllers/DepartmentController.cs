using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.DataAccess;
using Application.DataAccess.DataAccess;
using Application.DataAccess.Models;

namespace MVC_Application.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentDataAccess dataAccess;
        public DepartmentController()
        {
            dataAccess= new DepartmentDataAccess();
        }

        // GET: Department
        public ActionResult Index()
        {
            var depts = dataAccess.GetDepartments();
            // THe View Methods returns a View and decide
            // 1. A View NAme (Default Match with the Action Method NAme e.g. Index.cshtml)
            // 2. THis also can pass data to view 
            return View(depts);
        }

        /// <summary>
        /// HTTP Get Metod for CReating Create View with
        /// EMpty TextBoxes
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            dataAccess.CreateDepartment(department);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dept = dataAccess.GetDepartments(id);
            return View(dept);
        }
        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            dataAccess.UpdateDepartment(id, department);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var dept = dataAccess.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}