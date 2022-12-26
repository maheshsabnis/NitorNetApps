using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CS_Connected_App.Models;

namespace CS_Connected_App.DataAccess
{
    public class DepartmentDataAccess
    {
        SqlConnection? Conn;
        SqlCommand? Cmd;
        /// <summary>
        /// Define an instance of SqlConnection
        /// </summary>
        public DepartmentDataAccess()
        {
            string connStr = "Data Source=.;Initial Catalog=Company;Integrated Security=SSPI";
            //string connStr = "Data Source=.;Initial Catalog=Company;USer Id=[];PAssword=[]";
            Conn = new SqlConnection(connStr);
        }

        public List<Department> GetDepartments() 
        {
            List<Department> depts = new List<Department>();
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
            }
            catch (Exception ex)
            {
                // THrow Exception so that when this method throws an execption
                // The method caller will receiver it
                throw ex;
            }
            finally
            {
                Conn.Close();  
            }
            return depts;
        }

        public int CreateDepartment(Department dept)
        {
            int Result = 0;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                // USe Parameteized Queries instead of String Conacatination
                Cmd.CommandText = $"Insert into Department Values(@DeptNo,@DeptName,@Capacity,@Location)";
                // Pass the Parameter with Descriptive mechanism as follows
                SqlParameter pDeptNo = new SqlParameter();
                // Parameter Name
                pDeptNo.ParameterName = "@DeptNo";
                // Direction (Input (deault), Out, inputoutput)
                pDeptNo.Direction = System.Data.ParameterDirection.Input;
                // Datatype of the parameter
                pDeptNo.SqlDbType = System.Data.SqlDbType.Int;
                // Value
                pDeptNo.Value = dept.DeptNo;
                // Add the Parameter into the Parameters collection of Command Object
                Cmd.Parameters.Add(pDeptNo);


                SqlParameter pDeptName = new SqlParameter();
                pDeptName.ParameterName = "@DeptName";
                // Direction (Input (deault), Out, inputoutput)
                pDeptName.Direction = System.Data.ParameterDirection.Input;
                // Datatype of the parameter
                pDeptName.SqlDbType = System.Data.SqlDbType.VarChar;
                // ***IMPT If using Textual data then MUST set the size of the data
                // // default is 1 character
                pDeptName.Size = 100;   
                // Value
                pDeptName.Value = dept.DeptName;
                // Add the Parameter into the Parameters collection of Command Object
                Cmd.Parameters.Add(pDeptName);


                SqlParameter pCapacity = new SqlParameter();
                pCapacity.ParameterName = "@Capacity";
                pCapacity.Direction = System.Data.ParameterDirection.Input;
                pCapacity.SqlDbType = System.Data.SqlDbType.Int;
                pCapacity.Value = dept.Capacity;
                Cmd.Parameters.Add(pCapacity);


                SqlParameter pLocation = new SqlParameter();
                pLocation.ParameterName = "@Location";
                pLocation.Direction = System.Data.ParameterDirection.Input;
                pLocation.SqlDbType = System.Data.SqlDbType.VarChar;
                pLocation.Size = 100;
                pLocation.Value = dept.Location;
                Cmd.Parameters.Add(pLocation);

                 Result = Cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return Result;    
        }

        public int UpdateDepartment(int deptno, Department dept)
        {
            int Result = 0;
            try
            {
                if (dept == null)
                    throw new Exception("Object to update must nt be null");
                // CHeck if the deptno mathes with deptno in dept object
                if (deptno != dept.DeptNo)
                    throw new Exception($"The Search Critecria and objet update does not mah match");
                // search the object before update (optinal)
                // USe Select query to search record that is to be updated
                // if not found then throw exception (BUT this will have one more db call)

                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Update Department set DeptName=@DeptName, Capacity=@Capacity,Location=@Location where DeptNo=@DeptNo";

                // Short way to pass parameters
                // use this if seperate valiation for parameters are already done
                Cmd.Parameters.AddWithValue("@DeptNo", dept.DeptNo);
                Cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                Cmd.Parameters.AddWithValue("@Capacity", dept.Capacity);
                Cmd.Parameters.AddWithValue("@Location", dept.Location);
                
                Result= Cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return Result;
        }

        public bool DeleteDepartment(int deptno)
        {
            bool isSuccess = false;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Delete from Department where DeptNo=@DeptNo";
                Cmd.Parameters.AddWithValue("@DeptNo", deptno);
                int result = Cmd.ExecuteNonQuery();
                if(result > 0)
                    isSuccess = true;
    
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Conn.Close();
            }
            return isSuccess;
        }

    }
}
