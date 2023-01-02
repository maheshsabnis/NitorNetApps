using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_App
{
    public class EmployeeDbAccess : IDbAccess<Employee, int>
    {
        Employee IDbAccess<Employee, int>.Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        Employee IDbAccess<Employee, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IDbAccess<Employee, int>.Get()
        {
            throw new NotImplementedException();
        }

        Employee IDbAccess<Employee, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Employee IDbAccess<Employee, int>.Update(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
