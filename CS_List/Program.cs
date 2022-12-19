// See https://aka.ms/new-console-template for more information
Console.WriteLine("Generic List");
List<int> lstInt= new List<int>();
lstInt.Add(10);
lstInt.Add(20);
lstInt.Add(30);

foreach (int item in lstInt)
{
    Console.WriteLine(item) ;
}

List<string> lstString= new List<string>();
lstString.Add("Tejas");
lstString.Add("Mahesh");
lstString.Add("Ramesh");
lstString.Add("Ram");

foreach (string item in lstString)
{
    Console.WriteLine(item);
}
Console.ReadLine(); 
