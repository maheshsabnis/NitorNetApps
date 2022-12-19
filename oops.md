<h2> C# Features </h2>

<h2>Inheritance</h2>
    - Inheritance <br/>
        - It is a process of deriving the most specific implementation from the generalize implementation <br/>
            - e.g. <br/>
                - The Shape is a a very genelized word. It only specifies dimensions e.g. Height, Width,Depth, Area etc. But it does not spcifies what the shape actually is. To specify the specific shape, we need to use words like Rectangle, Traingle, Square, Circle, etc. This means that we can say that all these are type of shapes but with specific visibility. <br/>
                -  In case of Object Oriented Programming (OOPs), we use this terminology as the 'Inheritance'.<br/>
                - While developing a software system the inheritance provides the specific implementation for writing the application <br/>
                    - e.g. <br/>
                        - In case of the Payroll System, we have Base class as Employee where we can define a Employee class with specific information e.g. EmpNo, EmpName, DeptName, etc. But for calculating Payroll, we need various designations based classes  e.g. Manager, Engineer,Developer, etc. These classes are dertived from Employee base class. These derived classes contains properties spercific to the respecitve designation so that payroll calculation can be done easily.      
    - <h2>Pros of Inheritance</h2>
        - Reduce the code redundancy. <br/>
        - Provides code reusability. <br/>
        - Improved Code Readability. <br/>
        - Reduce the coed size. <br/>
        - Helps to divide and write the code in more sepcific class implementation. <br/>
        - Provide the code extensibility by overriding the base class functionality. <br/>
    - <h2>Cons of Inheritance</h2>
        - Code is tightly coupled from the base class to derived class. <br/>
        - If the code in base class changes that may impact the derived class <br/>
        - In some cases the derivbed class need not to use all data members of the  base class (very unlikely, but may be possible), in this case ythe memory allocated to such unsed data members will impact the performance. While using inheritance, you must be careful while declaring data members. <br/> 
        
    - Single Inheritance <br/>
        - Here we have a Single class derived from a Base class <br/>
            - e.g. <br/>
                - class Base {} <br/>
                - class Derive:Base{} <br/>
```` csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Single Inheritance");
Manager mgr = new Manager(101, "Mahesh", 34000, 6000);
Console.WriteLine($"Calculation {mgr.CalculateSalary()}");
Console.ReadLine();

public abstract class Employee
{
    protected int EmpNo = 0;
    protected string EmpName = String.Empty;    
    protected double BasicSalary = 0;
    public Employee(int eno, string ename, double basicSal)
    {
        EmpNo = eno;
        EmpName = ename;    
        BasicSalary = basicSal; 
    }

    public virtual double CalculateSalary()
    {
        return BasicSalary;
    }
}
/// <summary>
/// The Single Inheritance
/// </summary>
public class Manager : Employee
{
    private double PetrolAllowance = 0;
    public Manager(int eno = 0, string ename = "", double basicSal = 0, double petrolAllowance = 0):base(eno, ename, basicSal)
    {
        PetrolAllowance = petrolAllowance;
    }
    public override double CalculateSalary()
    {
        Console.WriteLine($"The Salary for Employee with EmpNo =  {EmpNo} and EmpName = {EmpName} ");
        return BasicSalary + PetrolAllowance;   
    }
}


````
    - Hierarchical Inheritance <br/>
        - Multiple classes are derived from the one base class <br/>
            - e.g. <br/>
                - class Base {} <br/>
                - class Derive1 : Base {} <br/>
                - class Derive2 : Base {} <br/>
                - class Derive3 : Base {} <br/>
```` csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hierarchical Inheritance");
Manager mgr = new Manager(101, "Mahesh", 34000, 6000);
Console.WriteLine($"Manager Salary Calculation {mgr.CalculateSalary()}");

Engineer engineer = new Engineer(102, "Tejas", 45000, 25000);
Console.WriteLine($"Engineer Salary Calculation {engineer.CalculateSalary()}");
Console.ReadLine();

public abstract class Employee
{
    protected int EmpNo = 0;
    protected string EmpName = String.Empty;
    protected double BasicSalary = 0;
    public Employee(int eno, string ename, double basicSal)
    {
        EmpNo = eno;
        EmpName = ename;
        BasicSalary = basicSal;
    }

    public virtual double CalculateSalary()
    {
        return BasicSalary;
    }
}
/// <summary>
/// The First Inherited Class
/// </summary>
public class Manager : Employee
{
    private double PetrolAllowance = 0;
    public Manager(int eno = 0, string ename = "", double basicSal = 0, double petrolAllowance = 0) : base(eno, ename, basicSal)
    {
        PetrolAllowance = petrolAllowance;
    }
    public override double CalculateSalary()
    {
        Console.WriteLine($"The Salary for Employee with EmpNo =  {EmpNo} and EmpName = {EmpName} ");
        return BasicSalary + PetrolAllowance;
    }
}


/// <summary>
/// The Second Inherited Class
/// </summary>
public class Engineer : Employee
{
    private double OverTimeAllowance = 0;
    public Engineer(int eno = 0, string ename = "", double basicSal = 0, double ota = 0) : base(eno, ename, basicSal)
    {
        OverTimeAllowance = ota;
    }
    public override double CalculateSalary()
    {
        Console.WriteLine($"The Salary for Employee with EmpNo =  {EmpNo} and EmpName = {EmpName} ");
        return BasicSalary + OverTimeAllowance;
    }
}

````
    - Multi-Level Inheritance <br/> 
        - When a class is derived from another derived class then it is called as Multi-Level Inheritance <br/>
       
        - E.g. <br/> 
            - class Base{} <br/> 
            - class Derive1:Base {} <br/> 
            - class Derive2: Derive1 {} <br/>  
```` csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hierarchical Inheritance");
Manager mgr = new Manager(101, "Mahesh", 34000, 6000);
Console.WriteLine($"Manager Salary Calculation {mgr.CalculateSalary()}");

ProjectManager projectManager = new ProjectManager(101, "Mahesh", 34000, 6000,20000);
Console.WriteLine($"Project Manager Salary Calculation {projectManager.CalculateSalary()}");

Console.ReadLine();

public abstract class Employee
{
    protected int EmpNo = 0;
    protected string EmpName = String.Empty;
    protected double BasicSalary = 0;
    public Employee(int eno, string ename, double basicSal)
    {
        EmpNo = eno;
        EmpName = ename;
        BasicSalary = basicSal;
    }

    public virtual double CalculateSalary()
    {
        return BasicSalary;
    }
}
/// <summary>
/// The First Inherited Class
/// </summary>
public class Manager : Employee
{
    protected double PetrolAllowance = 0;
    public Manager(int eno = 0, string ename = "", double basicSal = 0, double petrolAllowance = 0) : base(eno, ename, basicSal)
    {
        PetrolAllowance = petrolAllowance;
    }
    public override double CalculateSalary()
    {
        Console.WriteLine($"The Salary for Employee with EmpNo =  {EmpNo} and EmpName = {EmpName} ");
        return BasicSalary + PetrolAllowance;
    }
}
/// <summary>
/// The ProjectManager class is derived from the Manager Base class
/// Manager itself is a derived class from Employee so here we have an 
/// example of the Multi-Level Inheritance
/// </summary>
public class ProjectManager : Manager 
{
    private double TravelAllowance = 0;
    public ProjectManager(int eno = 0, string ename = "", double basicSal = 0, double petrolAllowance = 0, double ta = 0) :base(eno, ename, basicSal, petrolAllowance)
    {
        TravelAllowance = ta;
    }

    public override double CalculateSalary()
    {
        return  BasicSalary + PetrolAllowance + TravelAllowance;
    }
}
````
            


<h2> Polymorphism </h2>
	- This allows to invoke methods of derived class through base class reference during runtime. <br/>
	- This has the ability for classes to provide different implementations of methods that are called through the same name. <br/>
	- At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. <br/>
	- Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation. <br/>
	- At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method.  <br/>


```` csharp
 
Console.WriteLine("Simple Polymorphism");
// Define the Base class Reference and instantiate it using the derived class
Shape shape = new Circle(100,200);
Console.WriteLine($"Area of the Circle = {shape.CalculateArea()}");
// Cast the BAsse class object using the derived class to access methods of the Derived class 
// Downcasting
Console.WriteLine($"Circumfrance of the Circle = {((Circle)shape).GetCircumference()}");
Console.ReadLine();
 

public abstract class Shape
{
    protected double height, width = 0;

    public Shape(double h, double w)
    {
        height = h;
        width = w;
    }

    public virtual double CalculateArea()
    {
        Console.WriteLine("Method call for the base class");
        return 0;
    }
}

public class Circle : Shape
{
    double radius = 0;
    public Circle(double h = 0, double w = 0) : base(h, w)
    {
        radius = width / 2;
    }
    public override double CalculateArea()
    {
        Console.WriteLine("Calculating the area of the Area");
        
        return (Math.PI * radius * radius);
    }

    public double GetCircumference()
    {
        return 2 * Math.PI * radius; 
    }
}


````


	- Using Dynamic Polymorphism aka Runtime Polymorphism <br/>
		- Dynamic polymorphism is implemented by abstract classes and virtual functions. <br/>




```` csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Using Dynamic Polymorophism");


Client client = new Client();
// Define an instance of the Traingle and Shape classes

Traingle traingle = new Traingle(100,200);
Rectangle rectangle = new Rectangle(100,200);
// Decide which 'CalculateArea()' method is to be called at runtime
client.Caller(traingle);
client.Caller(rectangle);
/// <summary>
/// The Abstract Class
/// </summary>
public abstract class Shape
{
    protected int height, width = 0;

    public Shape(int h, int w)
    {
        height = h;
        width = w;
    }

    public virtual int CalculateArea()
    {
        Console.WriteLine("Method call for the base class");
        return 0;
    }
}

public class Traingle : Shape
{
    public Traingle(int h = 0,int w = 0):base(h,w)
    {
    }
    public override int CalculateArea()
    {
        Console.WriteLine("Calculating the area of the Traingle");
        return (width * height / 2);
    }
}

public class Rectangle : Shape
{
    public Rectangle(int h = 0, int w = 0) : base(h, w)
    {
    }
    public override int CalculateArea()
    {
        Console.WriteLine("Calculating the area of the Rectangle");
        return (width * height);
    }
}

public class Client
{
    public void Caller(Shape shape)
    {
        int area = 0;
        area = shape.CalculateArea();
        Console.WriteLine($" Area = {area}");
    }
}


````