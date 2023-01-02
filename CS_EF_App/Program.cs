using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Entoty FRamework");

            IDbAccess<Department,int> deptDbAccess = new DepartmentDbAccess();

            var result = deptDbAccess.Get();
            Print(result);

            var dept = new Department()
            {
                 DeptNo = 202,DeptName="Medicine",Capacity=300,Location="Pune"
            };
            deptDbAccess.Create(dept);
             result = deptDbAccess.Get();
            Print(result);

            Console.ReadLine();
        }
        static void Print(IEnumerable<Department> departments)
        {
            Console.WriteLine("List of Departments");
            foreach (Department dept in departments)
            {
                Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Capacity} {dept.Location}");
            }
            Console.WriteLine("Ends Here");
        }
    }

    
}
