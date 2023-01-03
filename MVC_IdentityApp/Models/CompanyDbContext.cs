using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVC_IdentityApp.Models
{
    public partial class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
            : base("name=CompanyDbContext")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Designation)
                .IsUnicode(false);
        }
    }
}
