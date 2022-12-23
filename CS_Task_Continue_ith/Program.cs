
// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Task Continuetion");
FileOperations op = new FileOperations();
// OBject deflared on Main or Caller THread
Results Results = new Results();
try
{
    Task<string> task = Task<string>.Factory.StartNew(() =>
    {
        var data1 = op.ReadFileFirstReturnAsync(@"c:\NitorEltp\File1.txt").Result;
        // Setting Vaue for the object that is present on aller THread
        // Results.File1 = data1;
        Console.WriteLine($"Data from File1 in First Task {data1} ");
        return data1;
    }).ContinueWith((t) =>
    {
        if (t.Result == string.Empty || t.Result.Length == 0 || t.Result == null)
            throw new Exception("Sorry! It seems Task 1 is Failed");
        // USe the Result of Copletion of Task 1 in Task 2
        Results.File1 = t.Result;
        var data2 = op.ReadFileSecondReturnAsync(@"c:\NitorEltp\File2.txt").Result;
        // Setting Vaue for the object that is present on aller THread
        Results.File2 = data2;
        return data2;

    });

    var finalResult = task.Result;

    Console.WriteLine($"Fina Resut = {finalResult}");
    Console.WriteLine($"Results from Both Tasks {Results.File1} and {Results.File2}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error : {ex.Message}");
}

Console.WriteLine();

Console.WriteLine("Get Payment Details");

Tax tax = new Tax(400000);
Payment payment = new Payment();
Task<Payment> taskPayment = Task<Payment>.Factory.StartNew(() => 
{
    payment.TDS = tax.GetTDS();
    return payment;
}).ContinueWith((t1) => 
{
    payment.GST = tax.GetGST(400000);
    return payment;
}).ContinueWith((t2) => 
{
    payment.NetPayment = tax.GetNetPayment(400000, payment.TDS, t2.Result.GST);
    return payment;
});

Console.WriteLine($"GST {payment.GST} TDS {payment.TDS} Net Payment {payment.NetPayment}");




Console.ReadLine();


public class Results
{
    public string? File1 { get; set; }
    public string? File2 { get; set; }
}


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

         
        return fileData;
    }

    public async Task<string> ReadFileSecondReturnAsync(string fileName)
    {
        string fileData = String.Empty;
        using (StreamReader sr = new StreamReader(fileName))
        {
            fileData = await sr.ReadToEndAsync();
        }
 
        return fileData;
    }
}

class Payment
{
    public decimal NetIncome { get; set; }
    public decimal TDS { get; set; }
    public decimal GST { get; set; }
    public decimal NetPayment { get; set; }
}

class Tax
{
    private decimal NetIncome = 0;
    private decimal tds;
    private decimal gst;
    public Tax(decimal netIncome)
    {
        NetIncome = netIncome;
    }

    public decimal GetTDS()
    {

        if (NetIncome > 100000)
            tds = NetIncome * Convert.ToDecimal(0.2);
        else
            tds = NetIncome * Convert.ToDecimal(0.1);

        return tds;
    }

    public decimal GetGST(decimal netIncome)
    {
        gst = netIncome * Convert.ToDecimal(0.18);
        return gst;
    }

    public decimal GetNetPayment(decimal netIncome, decimal tds, decimal gst)
    {
        return netIncome - tds + gst;
    }
}