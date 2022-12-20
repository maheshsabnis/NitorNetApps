// See https://aka.ms/new-console-template for more information
using CS_Inhertence.Accountant;
using CS_Inhertence.Logic;
using CS_Inhertence.Models;
using System.Text.Json;

Console.WriteLine("DEMO Inheritence");
// Instantiatig the BAse with DErive
Staff doctor = new Doctor() 
{
  StaffId = 1,StaffName="Dr.No",ContactNo="9999999",BasicPay=120000,
  DoctorId = 1001,Degree="MBBS",Specialization="Heart",MaxPatientsPerDay=100,
  MaxOPerationsPerDay = 5,PerOperationFees=30000,PerPatientFeses=500
};

DoctorLogic doctorLogic = new DoctorLogic ();
doctorLogic.Register(doctor);
Console.WriteLine("Doctors");
foreach (var record in doctorLogic.GetStaff())
{
    /// Since the GLobal LIst is used for Doctors and Nurses the Casting is needed
    if (record.GetType() == typeof(Doctor))
    {
        Console.WriteLine(JsonSerializer.Serialize((Doctor)record));
    }
   
}

Console.WriteLine();
Staff nurse = new Nurse()
{
    StaffId = 2,
    StaffName = "Sister. Nirmala",
    ContactNo = "9899999",
    BasicPay = 120000,
   NoOfPatientsAssigned= 10,
   PayPerPatient= 900
};

NurseLogic nurseLogic = new NurseLogic();
nurseLogic.Register(nurse);
Console.WriteLine("Nurses");
foreach (var record in nurseLogic.GetStaff())
{
    /// Since the GLobal LIst is used for Doctors and Nurses the Casting is needed
    if (record.GetType() == typeof(Nurse))
    {
        Console.WriteLine(JsonSerializer.Serialize((Nurse)record));
    }
}

Console.WriteLine();
Console.WriteLine("Print Tax Details");

Accountancy accountancy = new Accountancy();
accountancy.PrintTotalIncomeNetIncomeTax(doctorLogic, doctor, out double total, out double net, out double tax);

Console.WriteLine($"For Docto {doctor.StaffId}, Total Income is Rs {total}/-, Tax is Rx. {tax}/- and Net income is Rs. {net}/- ");

Console.WriteLine();

accountancy.PrintTotalIncomeNetIncomeTax(nurseLogic, nurse, out double total1, out double net1, out double tax1);

Console.WriteLine($"For Nurse {doctor.StaffId}, Total Income is Rs {total1}/-, Tax is Rx. {tax1}/- and Net income is Rs. {net1}/- ");


Console.ReadLine();
