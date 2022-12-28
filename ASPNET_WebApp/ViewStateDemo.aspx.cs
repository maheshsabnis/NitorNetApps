using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET_WebApp
{
    public partial class ViewStateDemo : System.Web.UI.Page
    {
        static string Name = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnset_Click(object sender, EventArgs e)
        {
            Name= txtname.Text;
            txtname.Text = "";
        }

        protected void btnget_Click(object sender, EventArgs e)
        {
            txtname.Text = Name;
        }
    }
}