// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Parallel Invoke");

Console.WriteLine("Parallelly Read Data from Files");
FileOperations operations = new FileOperations();   
string fileData1 = string.Empty, fileData2 = string.Empty;
Parallel.Invoke(() => 
{
    // Request a THread, ALlocate method on thread, compete execution, release thread, retrieve data  
   fileData1 =  operations.ReadFileFirstReturn(@"C:\NitorEltp\File1.txt");
   fileData2 =  operations.ReadFileSecondReturn(@"C:\NitorEltp\File2.txt");

});

Console.WriteLine($"File Data 1 {fileData1}");
Console.WriteLine($"File Data 1 {fileData2}");

Console.ReadLine();




class FileOperations
{
    public void ReadFileFirst(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader (fileName))
        {
             fileData = sr.ReadToEnd ();
            Thread.Sleep (5000);
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
