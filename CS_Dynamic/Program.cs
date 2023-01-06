// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var x = 10;
dynamic y = new { id=10, name='A'};

Console.WriteLine($"x ={x} and  y  = {y.GetType()} and y.id = {y.id} and y.name = {y.name}");

y = 100;
Console.WriteLine($"Lates Value of y = {y}");

fun1(y);
 

Console.ReadLine();

static void fun1(dynamic f)
{
    Console.WriteLine($"In Method f = {f} and typeof y = {f.GetType()}" );

}