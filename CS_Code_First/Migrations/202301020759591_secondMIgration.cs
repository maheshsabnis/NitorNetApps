namespace CS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMIgration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DeptName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Departments", "Location", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Employees", "EmpName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employees", "Designation", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Designation", c => c.String());
            AlterColumn("dbo.Employees", "EmpName", c => c.String());
            AlterColumn("dbo.Departments", "Location", c => c.String());
            AlterColumn("dbo.Departments", "DeptName", c => c.String());
        }
    }
}
