// See https://aka.ms/new-console-template for more information
using CS_Interface;

Console.WriteLine("Demo Interface");
MathOp op1 = new MathOp();
Console.WriteLine($"Add = {op1.Add(2,4)} and Sub = {op1.Sub(7,6)}");
// INstantiate the Class usig INterface Reference
IMath op2 = new MathOp();
Console.WriteLine($"Add = {op2.Add(2, 4)} and Sub = {op2.Sub(7, 6)}");

IMath op3= new MathOp2();
Console.WriteLine($"Add = {op3.Add(4,7)} and Sub = {op3.Sub(7, 6)}");
IMathNew op4 = new MathOp2();

Console.WriteLine($"Add = {op4.Add(4, 7)} and Sub = {op4.Sub(7, 6)}");

Console.ReadLine();    
