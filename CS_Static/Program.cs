// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMo Static");
MyClass m = new MyClass();

m.Increment();
m.Decrement();
Console.ReadLine();


class MyClass
{
     static int i = 10;

    public static void Increment()
    {
        i++;
        Console.WriteLine($"Increment i = {i}");
    }

    public static void Decrement()
    {
        Console.WriteLine($"Before Decrement i = {i}");
        i--;
        Console.WriteLine($"After Derement i = {i}");
    }
}