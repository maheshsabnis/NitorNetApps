// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

StringOperations operations= new StringOperations();

string str = "James Wiliam Bond";

Console.WriteLine($"Length of {str} is = {operations.GetLength(str)}");
Console.WriteLine($"Upper Case of {str} is = {operations.GetUpperCase(str)}");

 
Console.WriteLine($"Reverse of {str} is = {operations.ReverseString(str)}");
Console.WriteLine();
Console.WriteLine($"Reverse of {str} is = {str.StringReverse()}");


Console.ReadLine();

sealed class StringOperations
{
    public int GetLength(string str)
    {
        return str.Length;
    }

    public string GetUpperCase(string str)
    {
        return str.ToUpper();
    }
}

static class Utilities
{
    /// <summary>
    /// ReverseString is an extensio method of StringOperations CLass
    /// </summary>
    /// <param name="op"></param>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ReverseString(this StringOperations op, string str)
    {
        string reverse = string.Empty;
        for (int i = str.Length-1; i >= 0; i--)
        {
            reverse += str[i];
        }
        return reverse;
    }


    public static string StringReverse(this  string str)
    {
        string reverse = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reverse += str[i];
        }
        return reverse;
    }
}