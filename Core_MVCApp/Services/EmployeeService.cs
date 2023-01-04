using Core_MVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_MVCApp.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        CompanyContext ctx;
        /// <summary>
        /// Lets Inject the COmpanyContext in this class
        /// </summary>
        public EmployeeService(CompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Employee> IService<Employee, int>.Create(Employee entity)
        {
            try
            {
                var record = await ctx.Employees.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return record.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Employee> IService<Employee, int>.Delete(int id)
        {
            try
            {
                var record = await ctx.Employees.FindAsync(id);
                if (record == null)
                    throw new Exception("Record is not found");
                ctx.Employees.Remove(record);
                await ctx.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task<IEnumerable<Employee>> IService<Employee, int>.GetAsync()
        {
            return await ctx.Employees.ToListAsync();
        }

        async Task<Employee> IService<Employee, int>.GetAsync(int id)
        {
            try
            {
                var record = await ctx.Employees.FindAsync(id);
                if (record == null)
                    throw new Exception("Record ot found");
                return record;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Employee> IService<Employee, int>.Update(int id, Employee entity)
        {
            try
            {
                var record = await ctx.Employees.FindAsync(id);
                if (record == null)
                    throw new Exception("Record ot found");
                record.EmpName = entity.EmpName;
                record.Designation= entity.Designation;
                record.Salary= entity.Salary;
                record.DeptNo= entity.DeptNo;
                await ctx.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
