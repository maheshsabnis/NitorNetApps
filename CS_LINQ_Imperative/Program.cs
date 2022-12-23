// See https://aka.ms/new-console-template for more information
using CS_LINQ_Imperative.Models;

Console.WriteLine("Imperative LINQ");
Employees employees = new Employees();

// Print ALl EMployees

var res1 = from e in employees
           select e;

Print(res1);

// Emps bt CTD DeptName
var res2 = from e in employees
           where e.DeptName == "CTD"
           select e;

Print(res2);

// Emps bt CTD DeptName by creatin a new Annymus Object at runtime 
var res3 = from e in employees
           where e.DeptName == "CTD"
           select new {
              EmployeeNo = e.EmpNo, EmployeeName = e.EmpName,Income=e.Salary,
              Tax = e.Salary * 0.2
           };

foreach (var item in res3)
{
    Console.WriteLine($"{item.EmployeeName} {item.EmployeeNo} {item.Income} {item.Tax}");
}

Console.WriteLine();

// Sum of Salary group by DeptName 

var res4 = (from e in employees
           group e by e.DeptName into DeptGroup // DeptGroup is new Resultant for each DeptName
           select new
           {
               DeptName = DeptGroup.Key, // The Property on which the group is created e.g. DeptName
               TotalSalary = DeptGroup.Sum(e => e.Salary)
           }).ToList(); // Convert The Result to LIst

foreach (var item in res4)
{
    Console.WriteLine($"DeptName {item.DeptName} and Total Salary {item.TotalSalary}");
}



var resObject = PrintEmployeesByDeptName(employees,"IT");

Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(resObject));


Console.ReadLine();

static void Print(IEnumerable<Employee> employees)
{
    foreach (var record in employees)
    {
        Console.WriteLine($"{record.EmpNo} {record.EmpName} {record.Salary} {record.DeptName} {record.Designation}");
    }
    Console.WriteLine();
}

/// EMpNo, EMpNAme, Income, and Tax
static object PrintEmployeesByDeptName(List<Employee> employees, string deptName)
{
   var result =  from e in employees
    where e.DeptName == "CTD"
    select new 
    {
        EmployeeNo = e.EmpNo,
        EmployeeName = e.EmpName,
        Income = e.Salary,
        Tax = e.Salary * 0.2
    };

    return result;
}