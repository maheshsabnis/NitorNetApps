using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Application.DataAccess.Models;
using Application.DataAccess.DataAccess;

namespace ASPNET_WebApp
{
    public partial class DeptDataAccess : System.Web.UI.Page
    {
        DepartmentDataAccess dataAccess;
        Department Dept;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataAccess= new DepartmentDataAccess();
            if (this.IsPostBack == false)
            {
                LoadData();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            txtdno.Text= string.Empty;  
            txtdname.Text= string.Empty;
            txtcap.Text= string.Empty;
            txtloc.Text= string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Dept = new Department()
            {
                DeptNo = Convert.ToInt32(txtdno.Text),
                DeptName = txtdname.Text,
                Capacity = Convert.ToInt32(txtcap.Text),
                Location = txtloc.Text  
            };

            dataAccess.CreateDepartment(Dept);
            LoadData();
        }

        private void LoadData()
        {
            gvDept.DataSource = dataAccess.GetDepartments();
            gvDept.DataBind();
        }

        protected void gvDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gvDept.SelectedRow;

            txtdno.Text = row.Cells[0].Text;
            txtdname.Text = row.Cells[1].Text;
            txtcap.Text = row.Cells[2].Text;
            txtloc.Text = row.Cells[3].Text;
        }

        protected void gvDept_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
             gvDept.SelectedIndex =  e.NewSelectedIndex;
             
            LoadData();
        }

        protected void gvDept_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDept.EditIndex= e.NewEditIndex;
            LoadData();
        }

        protected void gvDept_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
            



        }

        protected void gvDept_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDept.EditIndex = -1;
            LoadData();
        }

        protected void gvDept_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvDept.Rows[e.RowIndex];

            // LOgic for Update
            Dept = new Department();
            Dept.DeptNo = Convert.ToInt32( row.Cells[0].Text);
            Dept.DeptName = ((TextBox)row.Cells[1].Controls[0]).Text;
            Dept.Capacity = Convert.ToInt32 (((TextBox)row.Cells[2].Controls[0]).Text);
            Dept.Location = ((TextBox)row.Cells[3].Controls[0]).Text;
            dataAccess.UpdateDepartment(Dept.DeptNo, Dept);
            gvDept.EditIndex = -1;
            LoadData();
        }
    }
}