using CS_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CS_Code_First
{
    public class NitorCompanyDbContext : DbContext
    {
        public NitorCompanyDbContext():base("name=MyConn")
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
