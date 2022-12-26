using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_App_Dev_STandards.Models;
using CS_App_Dev_STandards.Operations;
namespace CS_App_Dev_STandards.DataAccess
{
    internal class EmployeeDbAccess : IDbAccess<Employee, int>
    {
        DbOpertaionResponse<Employee> IDbAccess<Employee, int>.Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Employee> IDbAccess<Employee, int>.Delete(int value)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Employee> IDbAccess<Employee, int>.GetData()
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Employee> IDbAccess<Employee, int>.GetData(int criteria)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Employee> IDbAccess<Employee, int>.Update(int value, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
