using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_App_Dev_STandards.Models;
using CS_App_Dev_STandards.Operations;
namespace CS_App_Dev_STandards.DataAccess
{
    public class DepartmentDbAccess : IDbAccess<Department, int>
    {
        SqlConnection? Conn;
        SqlCommand? Cmd;
        public DepartmentDbAccess()
        {
            string connStr = "Data Source=.;Initial Catalog=Company;Integrated Security=SSPI";
            Conn = new SqlConnection(connStr);
        }
        DbOpertaionResponse<Department> IDbAccess<Department, int>.Create(Department entity)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Department> IDbAccess<Department, int>.Delete(int value)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Department> IDbAccess<Department, int>.GetData()
        {
            List<Department> depts = new List<Department>();
            DbOpertaionResponse<Department> response = new DbOpertaionResponse<Department>();   
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "select * from Department ";
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    depts.Add(new Department()
                    {
                        DeptNo = Convert.ToInt32(reader["DeptNo"]),
                        DeptName = reader["DeptName"].ToString(),
                        Capacity = Convert.ToInt32(reader["Capacity"]),
                        Location = reader["Location"].ToString()
                    });
                }
                reader.Close();
                response.Response = depts;
                response.StatusMessage = "OPeration Completed Successfully";
                response.OperationStatusCode= 200;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Read Oeration Failed";
                response.OperationStatusCode = 500;
            }
            finally
            {
                Conn.Close();
            }
            return response;

        }

        DbOpertaionResponse<Department> IDbAccess<Department, int>.GetData(int criteria)
        {
            throw new NotImplementedException();
        }

        DbOpertaionResponse<Department> IDbAccess<Department, int>.Update(int value, Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
