// See https://aka.ms/new-console-template for more information
using CS_Tuples_Class.Models;

Console.WriteLine("DEMO Tuples");
Employees employees = new Employees();
Tuple<string> name = new Tuple<string>("Mahesh Rameshrao Sabnis");
Console.WriteLine($"Value Stored in Tuple is = {name.Item1}");

Tuple<int, string> data = new Tuple<int, string>(1111, "Tejas Mahesh Sabnis");
Console.WriteLine($"Value Stored in Tuple is = {data.Item1} and {data.Item2}");
ShowData(data);

var returnTuple = PrintData(data);
Console.WriteLine($"Value Stored in Tuple is = {returnTuple.Item1} and {returnTuple.Item2}");


Tuple<int, int, int, int, int, int, int, Tuple<int>> more = new System.Tuple<int, int, int, int, int, int, int,Tuple<int>>(1,2,3,4,5,6,7,new Tuple<int>(9));


var result = PrintEmployeesByDeptName(employees, "IT");



foreach (var item in result)
{
    Console.WriteLine($"{item.Item1} {item.Item2} {item.Item3} {item.Item4}");
}


// get the Destructured values

var res = PrintValues();
Console.WriteLine($"{res.Item1} {res.Item2}");

 

Console.ReadLine();

static void ShowData(Tuple<int,string> tuple)
{
    Console.WriteLine($"SHown in Method Value Stored in Tuple is = {tuple.Item1} and {tuple.Item2}");
}

static Tuple<int, string> PrintData(Tuple<int, string> tuple)
{
    Console.WriteLine($"SHown in Method Value Stored in Tuple is = {tuple.Item1} and {tuple.Item2}");

    Tuple<int, string> returnTuple = new Tuple<int, string>(tuple.Item1, tuple.Item2.ToUpper());
    return returnTuple;

}



static List<Tuple<int, string, int,double>> PrintEmployeesByDeptName(List<Employee> employees, string deptName)
{
    List<Tuple<int, string, int, double>> result = (from e in employees
                                                    where e.DeptName == deptName
                                                    select new Tuple<int, string, int, double>(e.EmpNo,e.EmpName,e.Salary,e.Salary * 0.2)).ToList();
                 
                    

    return result;
}



// Destructuring
static (int,int) PrintValues()
{
    int x = 10, y=20;
    return (x, y);
}