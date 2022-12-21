using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();

employees.Add("IT", new List<Employee>() { new Employee() { EmpNo = 1, EmpName = "A" }, new Employee { EmpNo = 2, EmpName = "B" } });
employees.Add("HR", new List<Employee>() { new Employee() { EmpNo = 3, EmpName = "C" }, new Employee { EmpNo = 4, EmpName = "D" } });


var isDataFound = employees.TryGetValue("IT1", out List<Employee> records);

if (isDataFound)
{
    foreach (var item in records)
    {
        Console.WriteLine($"{item.EmpNo} {item.EmpName}");
    }

}



Console.ReadLine();





public class Employee
{
    public int EmpNo { get; set; }
    public string? EmpName { get; set; }
   
}