using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_App
{
    public class DepartmentDbAccess : IDbAccess<Department, int>
    {
        Department IDbAccess<Department, int>.Create(Department entity)
        {
            throw new NotImplementedException();
        }

        Department IDbAccess<Department, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Department> IDbAccess<Department, int>.Get()
        {
            throw new NotImplementedException();
        }

        Department IDbAccess<Department, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Department IDbAccess<Department, int>.Update(int id, Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
