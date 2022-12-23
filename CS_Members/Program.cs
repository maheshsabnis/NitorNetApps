// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Members");
MyClass m = new MyClass();  
m.SetX(1);
m.SetY(2);

Console.WriteLine($"X = {m.GetX()} and  Y = {m.GetY()}");
Console.WriteLine();
MyClassProperties my = new MyClassProperties();
my.X = 10; my.Y = 20; // Call Set
Console.WriteLine($"X = {my.X} and Y = {my.Y} "); // Cal Get
Console.ReadLine();



public class MyClass
{
    int _X, _Y;

    public void SetX(int x)
    {
        _X = x; 
    }
    public int GetX() 
    {
        return _X; 
    }

    public void SetY(int y)
    {
        _Y = y;
    }

    public int GetY() 
    {
        return _Y;
    }
}

public class MyClassProperties
{ 
    int _X, _Y;

    // Create Public Properties
    public int X
    {
        get { return _X; } // Return value for _X
        set { _X = value; } // For Write value for _X
    }

    public int Y
    {
        get { return _Y; }
        set { _Y = value; }
    }
}

public class MyDataClass
{
    public int X { get; set; } // Auto-Implemented Properties C# 3.0
    public int Y { get; set; }
}

