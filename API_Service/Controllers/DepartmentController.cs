using API_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API_Service.Controllers
{
    public class DepartmentController : ApiController
    {
        CompanyDbContext ctx;

        public DepartmentController()
        {
            ctx = new CompanyDbContext();
        }

        public IHttpActionResult Get()
        {
            var result = ctx.Departments.ToList();
            var response = (from dept in result
                           select new Department()
                           {
                                DeptNo= dept.DeptNo,
                                DeptName = dept.DeptName,
                                Capacity = dept.Capacity,
                                Location= dept.Location
                           }).ToList();
            return Ok(response);
        }
        public IHttpActionResult Get(int id)
        {
            var result = ctx.Departments.Find(id);
            return Ok(result);
        }
        public IHttpActionResult Post(Department dept) 
        {
            if (ModelState.IsValid)
            {
                ctx.Departments.Add(dept);
                ctx.SaveChanges();
                return Ok(dept);
            }
            // return Error Message
            return BadRequest(ModelState);
        }
        public IHttpActionResult Put(int id,Department dept)
        {
            var result = ctx.Departments.Find(id);
            if (result == null)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                result.DeptName = dept.DeptName;
                result.Capacity= dept.Capacity;
                result.Location= dept.Location; 
                ctx.SaveChanges();
                return Ok(result);
            }
            // return Error Message
            return BadRequest(ModelState);
        }

        public IHttpActionResult Delete(int id)
        {
            var result = ctx.Departments.Find(id);
            if (result == null)
                return NotFound();
            ctx.Departments.Remove(result);
            ctx.SaveChanges();
            return Ok(result);
        }
    }

}
