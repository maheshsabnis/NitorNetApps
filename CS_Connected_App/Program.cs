using CS_Connected_App;
using CS_Connected_App.DataAccess;
using CS_Connected_App.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("ADO.NET Application Connected Archirecture");
DepartmentDataAccess deptAccess = new DepartmentDataAccess();	
Console.WriteLine("1. For All Records");
Console.WriteLine("2. For Insert");
Console.WriteLine("3. For Update");
Console.WriteLine("4. For Delete");
Console.WriteLine("ENter Choice");
int select = Convert.ToInt32(Console.ReadLine());
switch (select)
{
	case 1: 
			var depts = deptAccess.GetDepartments();
		foreach (var record in depts)
		{
			Console.WriteLine($"{record.DeptNo} {record.DeptName} {record.Capacity} {record.Location}");
		}		
		break;
case 2:
		var dept = new Department() { DeptNo=90,DeptName="Test", Capacity=400,Location="Pune"};
		deptAccess.CreateDepartment(dept);
		Console.WriteLine("INserted Successfully");
		break;
	case 3:
        var deptupdate = new Department() { DeptNo = 90, DeptName = "Test Automated", Capacity = 400, Location = "Pune" };
		int res = deptAccess.UpdateDepartment(90, deptupdate);
		Console.WriteLine($"For Update {res}");
        break;
	case 4:
		int deptno = 90;
		var isSuccess = deptAccess.DeleteDepartment(deptno);
		Console.WriteLine($"Deleted {isSuccess}");
		break;
	default:
		break;
}



Console.ReadLine();
