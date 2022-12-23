// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Async Await");
FileOperations operations= new FileOperations();
//Task<string> tResult = operations.ReadFileFirstReturnAsync(@"C:\NitorEltp\File1.txt");
//Console.WriteLine(tResult.Result);

var fileData = await operations.ReadFileFirstReturnAsync(@"C:\NitorEltp\File1.txt");


Console.ReadLine();


/// <summary>
/// The class with Async Methods
/// </summary>
class FileOperations
{

    /// <summary>
    /// A Method that will be executed Asynchronously
    /// Applied with 'async' as Modifier
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public async Task<string> ReadFileFirstReturnAsync(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            // an Awaitable Call
            // THis will handle an Async Execution like Sync on seperate thread 
            // without blocking the Caller or CUrrent Executing THread
            fileData = await sr.ReadToEndAsync();
        }

        Console.WriteLine($"Data From FIle 1 {fileData}");
        return fileData;
    }

    public string ReadFileSecondReturn(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            fileData = sr.ReadToEnd();
        }

        Console.WriteLine($"Data From FIle 2 {fileData}");
        return fileData;
    }
}
