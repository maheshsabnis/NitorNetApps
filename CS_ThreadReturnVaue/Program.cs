// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Thread Returning Value");

double resultPower = 0;

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("On Main THread");
}

 

Thread thread = new Thread(() => { resultPower = GetPower(45, 4); });
thread.Start();
// Lets Join the THread with Main THread so that its execution will be completed
// and main thread will receive data from it
thread.Join();
Thread t1 = new Thread(PrintMessages);
t1.Start();
Console.WriteLine("Resume BAck to MAin THread");

Console.WriteLine($"Power result in Main THread = {resultPower}");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Aain On Main THread");
}
Console.ReadLine();


static double GetPower(double x, double y)
{
    Console.WriteLine("IN the Seperate THread which is calculating Power");
    Thread.Sleep(5000);
    // DIscards, this declaration will be kiiled once the method is completed
    var _ =  Math.Pow(x, y);
    Console.WriteLine($"Power {y} raised to {x} = {_}");
    return _;
}

static void PrintMessages()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Message = {i}") ;
    }
}