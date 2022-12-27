using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                lstNames.Items.Add(new ListItem("1", "Tejas"));
                lstNames.Items.Add(new ListItem("2", "Mahesh"));
                lstNames.Items.Add(new ListItem("3", "Ramesh"));
                lstNames.Items.Add(new ListItem("4", "Ram"));
                lstNames.Items.Add(new ListItem("5", "Sabnis"));
            }
            
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            lblName.Text = $"{txtfname.Text} {txtlname.Text}";
        }

        protected void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblselectedname.Text = lstNames.Text;
        }
    }
}