using ASPNET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class SesinReceiver : System.Web.UI.Page
    {
        Employees employees; 
        protected void Page_Load(object sender, EventArgs e)
        {
            employees = new Employees();

            // Read Data from Session
            var name = Session["Name"].ToString();
            var dept = (Department)Session["Dept"];

            if (name == string.Empty)
            {
                gvEmps.DataSource = employees;
                gvEmps.DataBind();
            }
            else
            {
                gvEmps.DataSource = employees.Where(ep=>ep.DeptName == name).ToList();
                gvEmps.DataBind();
            }


        }
    }
}