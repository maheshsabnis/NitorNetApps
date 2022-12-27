using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNET_WebApp.Models;
namespace ASPNET_WebApp
{
    public partial class MasterDetails : System.Web.UI.Page
    {
        string[] Designations;
        Employees employees;
        protected void Page_Load(object sender, EventArgs e)
        {
            Designations = new string[] { "Manager", "Director", "Operator" };
            employees= new Employees();
            if (this.IsPostBack == false)
            {
                lstDesignation.DataSource= Designations;
                lstDesignation.DataBind();
                gvEmployees.DataSource = employees;
                gvEmployees.DataBind();
            }
        }

        protected void lstDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDesignation.Text.Trim() != string.Empty)
            {
                var filteredEmloyees = (from emp in employees
                                        where emp.Designation == lstDesignation.Text.Trim()
                                        select emp).ToList();

                gvEmployees.DataSource = filteredEmloyees;
                gvEmployees.DataBind();
            }
            else
            {
                gvEmployees.DataSource = employees;
                gvEmployees.DataBind();
            }
        }
    }
}