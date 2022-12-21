

namespace CS_Delegate
{
    // a. Define a Delegate Type
    public delegate int AddHandler(int a, int b);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Delegate DEmo");
            // Use 1: Invoke a method with its Reference
            // b. Create an instance of delegate and pass method reference to it
            AddHandler handler = new AddHandler(Add);
            // c. PAss Parameter to Delegate Type
            Console.WriteLine($"Add = {handler.Invoke(10,20)}");
            // Use Case 2: Using Anoynmous Method aka Passing Implementation to Delegate
            // C# 2.0
            AddHandler handler1 =  delegate (int x, int y) { return x + y; };
            Console.WriteLine($"Anonymous Method {handler1(100,300)}");

            // Access Method having input parameter as delegate
            Operation(delegate (int x, int y) { return x * y; });
            // C# 3.0 Lambda Expression
            Operation((a,b)=> { return (a * a) + 2 * a * b + (b * b); });

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// Method that has input parameter as delegate
        /// </summary>
        /// <param name="handler"></param>
        static void Operation(AddHandler handler)
        {
            Console.WriteLine($"Result of Operations = {handler(400,500)}");
        }
    }

}


