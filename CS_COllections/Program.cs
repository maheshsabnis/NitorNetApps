// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

ArrayList arr = new ArrayList();

arr.Add(10);
arr.Add(20);
arr.Add(30);
arr.Add(10.1);
arr.Add(20.2);
arr.Add("Mahesh");
arr.Add("Tejas");
arr.Add('A');
arr.Add('B');
arr.Add('Z');

foreach (object obj in arr)
{
    Console.WriteLine($"Type of obj = {obj.GetType()} and value = {obj}");
}

Console.WriteLine();
Console.WriteLine("ONly string");

foreach (object obj in arr)
{
    if (obj.GetType() == typeof(string))
    {
        Console.WriteLine(obj);
    }
}

Console.ReadLine(); 