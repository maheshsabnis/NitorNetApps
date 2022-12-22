// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Tasks");
FileOperations operations = new FileOperations();   
Task task = Task.Factory.StartNew(() => 
{
    operations.ReadFileFirst(@"C:\NitorEltp\File1.txt");
}); 


Console.ReadLine();


class FileOperations
{
    public void ReadFileFirst(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            fileData = sr.ReadToEnd();
            Thread.Sleep(5000);
        }

        Console.WriteLine($"Data From FIle 1 {fileData}");
    }

    public void ReadFileSecond(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            fileData = sr.ReadToEnd();
        }

        Console.WriteLine($"Data From FIle 2 {fileData}");
    }

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
