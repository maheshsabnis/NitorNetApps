// See https://aka.ms/new-console-template for more information
using CS_Abstraction_Encapsuation.Logic;
using CS_Abstraction_Encapsuation.Models;

Console.WriteLine("DEMO Encapsulation Abstraction");
//ClsStaff staff = new ClsStaff();

//staff.RegisterStaff(1001, "Mahesh", "Doctor", 10000);

//staff.RegisterStaff(1002, "Vikram", "Administrator", 30000);

//staff.RegisterStaff(1003, "SUprotim", "Wardboy", 6000);

//var staffs = staff.GetStaffs();
//foreach (var item in staffs)
//{
    
//}

StaffLogic logic = new StaffLogic();
Staff s1 = new Staff();
s1.StaffId = 1001;
s1.StaffName = "Dr. ANil";
s1.StaffCategory = "Doctor";
s1.Degree = "MBBS"; 
s1.BasicPay = 45000;
logic.RegisterStaff(s1);
logic.RegisterStaff(new Staff() { StaffId=1002, StaffName="Dr. No",StaffCategory="Doctor",BasicPay=45888,Degree="D.H.M.S" });
logic.RegisterStaff(new Staff() { StaffId=1003, StaffName="Sist. Nirmala",StaffCategory="Nurse",BasicPay=9000});

var staffs = logic.GetStaffs();
foreach (var item in staffs)
{
    Console.WriteLine($"{item.StaffId} {item.StaffName} {item.StaffCategory} {item.BasicPay} {item.Degree}");
}




Console.ReadLine();
