// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Task Returning Data");

FileOperations operations = new FileOperations();

Task<string> task = Task<string>.Factory.StartNew(() => 
{
    var fileData = operations.ReadFileFirstReturn(@"c:\NitorEltp\File1.txt");
    return fileData;
});

Console.WriteLine("Lets Collect THe result on Main THread");

Console.WriteLine($"Result = {task.Result}");

Console.ReadLine();


class FileOperations
{
    

    public string ReadFileFirstReturn(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            fileData = sr.ReadToEnd();
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
