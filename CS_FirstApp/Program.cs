
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Thread.CurrentThread.Name = "Main";
Temp();
Console.ReadLine();


static void Temp()
{
    Console.WriteLine($"THreads {Thread.CurrentThread.Name}");
}
