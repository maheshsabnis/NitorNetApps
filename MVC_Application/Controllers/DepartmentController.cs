using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.DataAccess;
using Application.DataAccess.DataAccess;
using Application.DataAccess.Models;
using MVC_Application.CustomFilters;
namespace MVC_Application.Controllers
{
    /// <summary>
    /// Approach 3 for Handling Exceptions
    /// For using Exception Filter ake sure that
    /// web.config has 'customError' model set to 'on' 
    /// </summary>
      [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    // Applied the Custom Filter
    //  [LogFilter]
    
    public class DepartmentController : Controller
    {
        DepartmentDataAccess dataAccess;
        /// <summary>
        /// Inject DepaetmentDataAccess dependency in COntroller
        /// </summary>
        /// <param name="ds"></param>
        public DepartmentController(DepartmentDataAccess ds)
        {
            // dataAccess= new DepartmentDataAccess();
            dataAccess = ds;
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
            // First Approach of hadling Exception
            //try
            //{
                // now validate the Department Model
                if (ModelState.IsValid)
                {
                    if (department.Capacity < 0)
                        throw new Exception("Capacity Cannot be -ve");
                    dataAccess.CreateDepartment(department);
                    return RedirectToAction("Index");
                }
                else
                {
                    // Stey on Same Page
                    return View(department);
                }
            //}
            //catch (Exception ex)
            //{
            //    // Return the Error Page and pass HandleErrInfo model with values
            //    //  return View("Error", new HandleErrorInfo(ex, "Department", "Create"));
            //    // Lets Generalized

            //    return View("Error", new HandleErrorInfo(
            //           ex, this.RouteData.Values["controller"].ToString(),
            //           this.RouteData.Values["action"].ToString()
            //         ));
            //}

        }
        /// <summary>
        /// One method for all action methos in controller
        /// Approach 2
        /// </summary>
        /// <param name="filterContext"></param>
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //     // 1. Set the ExceptionHandler property to true
        //     filterContext.ExceptionHandled= true;
        //    // 2.REad the Exception
        //    Exception ex = filterContext.Exception;
        //    // 3. set the result
        //    ViewDataDictionary viewData = new ViewDataDictionary();
        //    viewData["ControllerName"] = this.RouteData.Values["controller"].ToString();
        //    viewData["ActionName"] = this.RouteData.Values["action"].ToString();
        //    viewData["ExceptionMessage"] = ex.Message;
        //    filterContext.Result = new ViewResult() 
        //    { 
        //        ViewName = "Error",
        //        ViewData= viewData
        //    };
        //}

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

        public ActionResult ShowEmployees(int id)
        {
            var dept = dataAccess.GetDepartments(id);

            TempData["DeptNo"] = id;
            TempData["Dept"] = dept;
            // Idnex method from Employee Controller
            return RedirectToAction("Index", "Employee");
        }
    }
}