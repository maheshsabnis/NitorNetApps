using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Application.DataAccess.Models;

namespace Application.DataAccess.DataAccess
{
    public class EmployeeDataAccess
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        /// <summary>
        /// Define an instance of SqlConnection
        /// </summary>
        public EmployeeDataAccess()
        {
            string connStr = "Data Source=.;Initial Catalog=Company;Integrated Security=SSPI";
            //string connStr = "Data Source=.;Initial Catalog=Company;USer Id=[];PAssword=[]";
            Conn = new SqlConnection(connStr);
        }

        public List<Employee> GetEmployees() 
        {
            List<Employee> emps = new List<Employee>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "select * from Employee ";
                var reader = Cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    emps.Add(new Employee() 
                    {
                      EmpNo = Convert.ToInt32(reader["EmpNo"]),
                      EmpName = reader["EmpName"].ToString(),
                      Salary = Convert.ToInt32(reader["Salary"]),
                      Designation = reader["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(reader["DeptNo"])
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
            return emps;
        }



        public Employee GetEmployees(int empno)
        {
            Employee emp = new Employee();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "select * from Employee where EmpNo=@EmpNo";
                Cmd.Parameters.AddWithValue("@EmpNo", empno);
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {

                    emp.EmpNo = Convert.ToInt32(reader["empNo"]);
                    emp.EmpName = reader["empName"].ToString();
                    emp.Salary = Convert.ToInt32(reader["Capacity"]);
                    emp.Designation = reader["Location"].ToString();
                    emp.DeptNo = Convert.ToInt32(reader["DeptNo"]);

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
            return emp;
        }

        public int CreateEmployee(Employee emp)
        {
            int Result = 0;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                // USe Parameteized Queries instead of String Conacatination
                Cmd.CommandText = $"Insert into Employee Values(@EmpNo,@EmpName,@Designation,@Salary,@DeptNo)";
                // Pass the Parameter with Descriptive mechanism as follows
                SqlParameter pEmpNo = new SqlParameter();
                // Parameter Name
                pEmpNo.ParameterName = "@EmpNo";
                // Direction (Input (deault), Out, inputoutput)
                pEmpNo.Direction = System.Data.ParameterDirection.Input;
                // Datatype of the parameter
                pEmpNo.SqlDbType = System.Data.SqlDbType.Int;
                // Value
                pEmpNo.Value = emp.EmpNo;
                // Add the Parameter into the Parameters collection of Command Object
                Cmd.Parameters.Add(pEmpNo);


                SqlParameter pEmpName = new SqlParameter();
                pEmpName.ParameterName = "@EmpName";
                // Direction (Input (deault), Out, inputoutput)
                pEmpName.Direction = System.Data.ParameterDirection.Input;
                // Datatype of the parameter
                pEmpName.SqlDbType = System.Data.SqlDbType.VarChar;
                // ***IMPT If using Textual data then MUST set the size of the data
                // // default is 1 character
                pEmpName.Size = 100;
                // Value
                pEmpName.Value = emp.EmpName;
                // Add the Parameter into the Parameters collection of Command Object
                Cmd.Parameters.Add(pEmpName);


                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@Salary";
                pSalary.Direction = System.Data.ParameterDirection.Input;
                pSalary.SqlDbType = System.Data.SqlDbType.Int;
                pSalary.Value = emp.Salary;
                Cmd.Parameters.Add(pSalary);


                SqlParameter pDesignation = new SqlParameter();
                pDesignation.ParameterName = "@Designation";
                pDesignation.Direction = System.Data.ParameterDirection.Input;
                pDesignation.SqlDbType = System.Data.SqlDbType.VarChar;
                pDesignation.Size = 100;
                pDesignation.Value = emp.Designation;
                Cmd.Parameters.Add(pDesignation);

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.Direction = System.Data.ParameterDirection.Input;
                pDeptNo.SqlDbType = System.Data.SqlDbType.Int;
                pDeptNo.Value = emp.Salary;
                Cmd.Parameters.Add(pDeptNo);


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

        public int UpdateEmployee(int empno, Employee emp)
        {
            int Result = 0;
            try
            {
                if (emp == null)
                    throw new Exception("Object to update must nt be null");
                // CHeck if the empno mathes with empno in emp object
                if (empno != emp.EmpNo)
                    throw new Exception($"The Search Critecria and objet update does not mah match");
                // search the object before update (optinal)
                // USe Select query to search record that is to be updated
                // if not found then throw exception (BUT this will have one more db call)

                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Update Employee set EmpName=@EmpName, Designation=@Designation,Salary=@Salary,DeptNo=@DeptNo where EmpNo=@EmpNo";

                // Short way to pass parameters
                // use this if seperate valiation for parameters are already done
                Cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                Cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                Cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                Cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                Cmd.Parameters.AddWithValue("@EmpNo", emp.DeptNo);

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

        public bool DeleteEmployee(int empno)
        {
            bool isSuccess = false;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = "Delete from Employee where EmpNo=@EmpNo";
                Cmd.Parameters.AddWithValue("@EmpNo", empno);
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
