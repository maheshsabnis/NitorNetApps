using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Code_First.Models
{
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        [Required]
        [StringLength(100)]
        public string DeptName { get; set; }
        public int Capacity { get; set; }
        [Required]
        [StringLength(200)]
        public string Location { get; set; }
        // One-To-Many Relationship
        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        [Required]
        [StringLength(150)]
        public string EmpName { get; set; }
        [Required]
        [StringLength(50)]
        public string Designation { get; set; }
        public int Salary { get; set; }
        [Required]
        public int DeptNo { get; set; }
        // One-to-One Relatinship
        public Department Department { get; set; }
    }
}
