using ASPNET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class QueryStringReceiver : System.Web.UI.Page
    {
        Employees Employees;
        protected void Page_Load(object sender, EventArgs e)
        {
            Employees = new Employees();
            // Reading value from the Query String
           // lblName.Text = $"Received Value = {Request.QueryString["Name"]}";
           var dname = Request.QueryString["Name"].ToString();
            // Quuery to Employees
            var filteredEmployees = (from emp in Employees
                                    where emp.DeptName == dname.Trim() 
                                    select emp).ToList();

            gvEmployees.DataSource = filteredEmployees;
            gvEmployees.DataBind();
        }
    }
}