// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Strings");

string str = "C# is great. The .NET 6 is cross platform";

Console.WriteLine($"Length of {str} is = {str.Length}");

Console.WriteLine($"Last appearing index of 't' is {str.LastIndexOf('t')}");
Console.WriteLine($"Fisrt appearing index of 't' is {str.IndexOf('t')}");
int noofwhitespaces = 0;
foreach (char c in str)
{
    if (Char.IsWhiteSpace(c))
    {
        noofwhitespaces++;  
    }
}

Console.WriteLine($"Whitespaces cuont in {str} is = {noofwhitespaces}");


Console.ReadLine();
