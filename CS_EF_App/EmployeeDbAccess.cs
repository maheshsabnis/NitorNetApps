using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_App
{
    public class EmployeeDbAccess : IDbAccess<Employee, int>
    {
        CompanyDbContext ctx;

        public EmployeeDbAccess()
        {
            ctx = new CompanyDbContext();
        }

        Employee IDbAccess<Employee, int>.Create(Employee entity)
        {
            var result = ctx.Employees.Add(entity);
            ctx.SaveChanges();
            return result;
        }

        Employee IDbAccess<Employee, int>.Delete(int id)
        {
            var result = ctx.Employees.Find(id);
            if (result == null)
                throw new Exception($"Employee {id} is not found");

            // else delete it
            ctx.Employees.Remove(result);
            ctx.SaveChanges();
            return result;
        }

        IEnumerable<Employee> IDbAccess<Employee, int>.Get()
        {
            var result = ctx.Employees.ToList();
            return result;
        }

        Employee IDbAccess<Employee, int>.Get(int id)
        {
            var result = ctx.Employees.Find(id);
            return result;
        }

        Employee IDbAccess<Employee, int>.Update(int id, Employee entity)
        {
            var result = ctx.Employees.Find(id);
            if (result != null)
            {
                // update each property values
                result.EmpName = entity.EmpName;
                result.Designation = entity.Designation;
                result.Salary = entity.Salary;
                result.DeptNo= entity.DeptNo;
                ctx.SaveChanges();
            }
            return result;
        }
    }
}
