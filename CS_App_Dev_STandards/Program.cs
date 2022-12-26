using CS_App_Dev_STandards.Models;
using CS_App_Dev_STandards.Operations;
using CS_App_Dev_STandards.DataAccess;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IDbAccess<Department, int> dbAccess = new DepartmentDbAccess();
DbOpertaionResponse<Department> response = dbAccess.GetData();
if (response.Response != null || response.Response.Count() > 0)
{
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(response));
}
else
{
    Console.WriteLine("There may be an error");
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(response));
}

Console.ReadLine();

