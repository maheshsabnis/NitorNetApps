namespace CS_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMIgration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptNo = c.Int(nullable: false, identity: false),
                        DeptName = c.String(),
                        Capacity = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.DeptNo);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpNo = c.Int(nullable: false, identity: false),
                        EmpName = c.String(),
                        Designation = c.String(),
                        Salary = c.Int(nullable: false),
                        DeptNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpNo)
                .ForeignKey("dbo.Departments", t => t.DeptNo, cascadeDelete: true)
                .Index(t => t.DeptNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptNo", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DeptNo" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
