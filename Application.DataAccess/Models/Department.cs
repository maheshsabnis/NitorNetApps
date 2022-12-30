using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DataAccess.Models
{
    public class Department
    {
        [Required(ErrorMessage = "DeptNo is required")]
        [NumericNonNegative(ErrorMessage = "DeptNo cannot be -Ve")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
    }

    public class Employee
    {
        [Required(ErrorMessage = "EmpNo is required")]
        [NumericNonNegative(ErrorMessage = "EmpNo cannot be -ve")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int  Salary { get; set; }
        [Required(ErrorMessage = "DeptNo is required")]
        public int DeptNo { get; set; }
    }

    // A Custom Validator that will ake sure that the DeptNo/EmpNo will not accept -ve values

    public class NumericNonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(Convert.ToInt32(value) < 0) return false; return true;

        }
    }

}
