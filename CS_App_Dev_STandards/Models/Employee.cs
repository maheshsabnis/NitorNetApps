using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_App_Dev_STandards.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? EmpName { get; set; }
        public string? Designation { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }
}
