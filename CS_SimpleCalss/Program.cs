// See https://aka.ms/new-console-template for more information
using CS_SimpleCalss;

Console.WriteLine("DEMO Simple OOPs");
ClsMath m = new ClsMath();
Console.WriteLine("ENter x");
// COnverting String into INteger
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("ENter y");
int y = Convert.ToInt32(Console.ReadLine());

long resAdd = m.Add(x, y);
Console.WriteLine("Result of Add = " + resAdd);

long resSub = m.Sub(x, y);
Console.WriteLine($"Result of Substratcion is = {resSub}");

Console.ReadLine();
