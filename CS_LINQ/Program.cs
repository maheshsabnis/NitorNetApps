// See https://aka.ms/new-console-template for more information
using CS_LINQ.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

Console.WriteLine("DEMO LINQ");

Employees Employees = new Employees();

// Print ALl Employees

var allEmps = Employees.Select(e=>e);
Print(allEmps);
Console.WriteLine();
// Print All EMployees by DeptName

var allEmpsByDname = Employees.Where(e=>e.DeptName == "IT").AsParallel();

Print(allEmpsByDname);

// All Employees by IT DeptNAme Order By EMpName
var orderByNAme = allEmpsByDname.OrderBy(e => e.EmpName);
Print(orderByNAme);

// COmbine
var result = Employees.Where(e=>e.DeptName == "IT")
					.OrderBy(e => e.EmpName);
Print(result);
Console.ReadLine();

static void Print(IEnumerable<Employee> employees)
{
	foreach (var record in employees)
	{
		Console.WriteLine($"{record.EmpNo} {record.EmpName} {record.Salary} {record.DeptName} {record.Designation}");
	}
	Console.WriteLine();
}