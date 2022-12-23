using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tuples_Class.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? EmpName { get; set; }
        public int Salary { get; set; }
        public string? DeptName { get; set; }
        public string? Designation { get; set; }
    }

    public class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 1001, EmpName = "YashodaNandan", DeptName = "IT", Salary = 53000, Designation="Manager" });
            Add(new Employee() { EmpNo = 1002, EmpName = "DevkiNandan", DeptName = "CTD", Salary = 33000, Designation = "Operator" });
            Add(new Employee() { EmpNo = 1003, EmpName = "RadheShyam", DeptName = "SYS", Salary = 63000, Designation = "Director" });
            Add(new Employee() { EmpNo = 1004, EmpName = "Gopal", DeptName = "HRD", Salary = 13000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 1005, EmpName = "Govind", DeptName = "SYS", Salary = 93000, Designation = "Operator" });
            Add(new Employee() { EmpNo = 1006, EmpName = "Mohan", DeptName = "CTD", Salary = 63000, Designation = "Director" });
            Add(new Employee() { EmpNo = 1007, EmpName = "Madhav", DeptName = "IT", Salary = 23000 , Designation = "Manager" });
            Add(new Employee() { EmpNo = 1008, EmpName = "Milind", DeptName = "ACCTS", Salary = 53000, Designation = "Director" });
            Add(new Employee() { EmpNo = 1009, EmpName = "Vasudev", DeptName = "ACCTS", Salary = 63000, Designation = "Operator" });
            Add(new Employee() { EmpNo = 1010, EmpName = "Shridhar", DeptName = "IT", Salary = 83000, Designation = "Manager" });
        }
    }
}
