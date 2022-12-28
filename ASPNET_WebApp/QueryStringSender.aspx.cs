using ASPNET_WebApp.Models;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class QueryStringSender : System.Web.UI.Page
    {
        Departments departments;
        protected void Page_Load(object sender, EventArgs e)
        {
            departments = new Departments();
            if (this.IsPostBack == false)
            { 
                lstDepats.DataSource = departments;
                lstDepats.DataValueField= "DeptName";
                lstDepats.DataTextField = "DeptName";
                lstDepats.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string Value = $"{txtfname.Text} {txtlname.Text}";
            // Create a QueryString URL
            string url = $"QueryStringReceiver.aspx?Name={Value}";
            // TRansfer to Other Page aka MAke request for Other Page
            // so that the server will send reponse for the other page
            Response.Redirect(url);
        }

        protected void lstDepats_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = $"QueryStringReceiver.aspx?Name={lstDepats.SelectedItem.Text}";
            Response.Redirect(url);
        }
    }
}