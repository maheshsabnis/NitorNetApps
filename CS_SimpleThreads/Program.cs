// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Simple THreads");

// Assiging two methods to two THreads
Thread t1 = new Thread(Incremet);
Thread t2 = new Thread(Decremet);

// Lets Start the execution
t1.Start();
// Set the Priority to the t1 THread as highest
t1.Priority= ThreadPriority.Highest;    
t2.Start();




Console.ReadLine();    

static void Incremet()
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine($"Increment i = {i}");
        // Lets sleep the thraed for 500 milliseconds
        Thread.Sleep(500);
	}
}

static void Decremet()
{
    for (int i = 10; i >= 0; i--)
    {
        Console.WriteLine($"Decrement i = {i}");
        Thread.Sleep(500);
    }
}