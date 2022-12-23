// See https://aka.ms/new-console-template for more information

namespace CS_AsyncDelegate
{
    public delegate int Handler(int a, int b);
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Asynchronous Delegate");

            Handler handler = new Handler(Add);
            // Make Reuest to Perfprm Add Asynchronusly (on seperate thread)
            IAsyncResult ar = handler.BeginInvoke(10,20, null,null);

            while (!ar.IsCompleted)
            {
                Console.WriteLine("Still Tahe Asyn Add Operation is not done");
            }
            
            // SUnscription to Asyn Operation
            int result = handler.EndInvoke(ar);
            Console.WriteLine($"Resu = {result}");


            Console.ReadLine();
        }


        static int Add(int x, int y)
        {
            return (x * x) + (y * y) + 3 * x * y + 2 * x * y + 1000;
        }
    }
}





