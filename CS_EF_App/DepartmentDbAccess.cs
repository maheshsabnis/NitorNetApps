using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_App
{
    public class DepartmentDbAccess : IDbAccess<Department, int>
    {
        CompanyDbContext ctx;

        public DepartmentDbAccess()
        {
            ctx = new CompanyDbContext();  
        }

        Department IDbAccess<Department, int>.Create(Department entity)
        {
            var result = ctx.Departments.Add(entity);
            ctx.SaveChanges();
            return result;
        }

        Department IDbAccess<Department, int>.Delete(int id)
        {
            var result = ctx.Departments.Find(id);
            if (result == null)
                throw new Exception($"Department {id} is not found");

            // else delete it
            ctx.Departments.Remove(result);
            ctx.SaveChanges();
            return result;
        }

        IEnumerable<Department> IDbAccess<Department, int>.Get()
        {
           var result = ctx.Departments.ToList();
           return result;
        }

        Department IDbAccess<Department, int>.Get(int id)
        {
            var result = ctx.Departments.Find(id);
            return result;
        }

        Department IDbAccess<Department, int>.Update(int id, Department entity)
        {
            var result = ctx.Departments.Find(id);
            if(result != null)
            {
                // update each property values
                result.DeptName = entity.DeptName;
                result.Capacity= entity.Capacity;
                result.Location= entity.Location;
                ctx.SaveChanges();
            }
            return result;
        }
    }
}
