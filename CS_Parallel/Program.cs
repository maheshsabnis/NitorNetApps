// See https://aka.ms/new-console-template for more information
using CS_Parallel;
using System.Diagnostics;

Console.WriteLine("USe Non-Palallel and Parallel Approach to Process Collection");

var employees = new EmployeeList();

Console.WriteLine("Non-Parallel");

var nonParallelTimeSpan = Stopwatch.StartNew();

for (int i = 0; i < employees.Count; i++)
{
    employees[i] = ProcessTax.CalculateTax(employees[i]);
    Console.WriteLine($"TDS for Employee {employees[i].EmpNo} is = {employees[i].TDS}");
}

Console.WriteLine($"Total time to process the collection traditionally is = {nonParallelTimeSpan.ElapsedMilliseconds}");

Console.WriteLine();
var employees1 = new EmployeeList();
Console.WriteLine("Parallel");
var parallelTimeSpan = Stopwatch.StartNew();
Parallel.For(0,employees.Count, (i) => {
    employees1[i] = ProcessTax.CalculateTax(employees1[i]);
    Console.WriteLine($"TDS for Employee {employees[i].EmpNo} is = {employees[i].TDS}");
});
Console.WriteLine($"Total time to process the collection parallely is = {parallelTimeSpan.ElapsedMilliseconds}");










Console.ReadLine();
