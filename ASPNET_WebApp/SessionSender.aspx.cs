using ASPNET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class SessionSender : System.Web.UI.Page
    {
        Departments departments;
        protected void Page_Load(object sender, EventArgs e)
        {
            departments = new Departments();
            if (this.IsPostBack == false)
            {
                lstDepts.DataSource = departments;
                lstDepts.DataValueField = "DeptNo";
                lstDepts.DataTextField = "DeptName";
                lstDepts.DataBind();
            }

            lblSessionInfo.Text = $"Session Id: {Session.SessionID} " +
                $"Timout : {Session.Timeout} " +
                $"IsNewSession : {Session.IsNewSession}";

        }

        protected void lstDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Name"] = lstDepts.SelectedItem.Value;
            // Since the DataSoure takes 'departments' collection
            // each istItem will be 'Department' Object

            Department dept = new Department()
            {
                DeptNo = Convert.ToInt32(lstDepts.SelectedItem.Value),
                DeptName = lstDepts.SelectedItem.Text
            };

            Session["Dept"] = dept;
            // Transfer COntrole to Receiver Page
            Server.Transfer("SesinReceiver.aspx");
        }
    }
}