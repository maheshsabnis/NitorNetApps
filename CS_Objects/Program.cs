// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person p1= new Person() { Id=1,Name="A"};
p1.Print();
p1.Name = "C";
p1.Print();
Person p2 = new Person() { Id = 1, Name = "B" };

Console.WriteLine(p1 == p2);

Console.WriteLine(Object.ReferenceEquals(p1, p2));


Employee employee = new Employee()
{
    Allowances = 200000,Salary=9999
};
if (employee.PersonalDetails != null)
{
    Console.WriteLine(employee.PersonalDetails.Id);
}
Console.WriteLine(employee.Salary);


Console.ReadLine();


//public class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}


public record Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Print()
    {
        Console.WriteLine($"{Id} {Name}");
    }
}

public class Employee
{
    //Referece TYpe Property
    public Person? PersonalDetails { get; set; }
    public decimal Salary { get; set; }
    public decimal Allowances { get; set; }
}