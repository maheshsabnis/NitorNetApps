using Core_MVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_MVCApp.Services
{
    public class DepartmentService : IService<Department, int>
    {
        CompanyContext ctx;
        /// <summary>
        /// Lets Inject the COmpanyContext in this class
        /// </summary>
        public DepartmentService(CompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Department> IService<Department, int>.Create(Department entity)
        {
            try
            {
                var record = await ctx.Departments.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return record.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Department> IService<Department, int>.Delete(int id)
        {
            try
            {
                var record = await ctx.Departments.FindAsync(id);
                if (record == null)
                    throw new Exception("Record is not found");
                ctx.Departments.Remove(record);
                await ctx.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            try
            {
                var record = await ctx.Departments.FindAsync(id);
                if (record == null)
                    throw new Exception("Record ot found");
                return record;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<Department> IService<Department, int>.Update(int id, Department entity)
        {
            try
            {
                var record = await ctx.Departments.FindAsync(id);
                if (record == null)
                    throw new Exception("Record ot found");
                record.DeptName = entity.DeptName;
                record.Capacity= entity.Capacity;
                record.Location= entity.Location;
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
