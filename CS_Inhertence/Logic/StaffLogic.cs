using CS_Inhertence.Database;
using CS_Inhertence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inhertence.Logic
{
    public abstract class StaffLogic
    {
        public abstract void Register(Staff staff);
        public abstract List<Staff> GetStaff();
        public virtual double CalcuateIncome(Staff staff)
        {
            return staff.BasicPay;
        }
    }
    /// <summary>
    /// sealed: The class will be preveted from any derivation
    /// </summary>
    public sealed class DoctorLogic :StaffLogic
    {
       // List<Staff> doctors= new List<Staff>();   
        public override void Register(Staff staff)
        {
           // doctors.Add((Doctor)staff);
           StaffDb.Staffs.Add((Doctor)staff);
        }

        public override List<Staff> GetStaff()
        {
            return StaffDb.Staffs;
        }

        public override double CalcuateIncome(Staff staff)
        {
            double totalIncome = 0;
            var basic =  base.CalcuateIncome(staff);
            // STore Staff ito DOctor
            Doctor doctor = (Doctor)staff;
            var totalPatientFees =doctor.MaxPatientsPerDay * doctor.PerPatientFeses;
            var totalOPerationFees = doctor.MaxOPerationsPerDay * doctor.PerOperationFees;
            totalIncome = basic + totalOPerationFees+ totalPatientFees;
            return totalIncome;
        }
    }

    
    public class NurseLogic : StaffLogic
    {
      //  List<Staff> nurses= new List<Staff>();  
        public override void Register(Staff staff)
        {
          //  nurses.Add((Nurse)staff);
          StaffDb.Staffs.Add((Nurse)staff);
        }
        public override List<Staff> GetStaff()
        {
           return StaffDb.Staffs;
        }
        public override double CalcuateIncome(Staff staff)
        {
            var basic =  base.CalcuateIncome(staff);
            Nurse nurse =(Nurse)staff;
            var incomeFromPatients = nurse.PayPerPatient * nurse.NoOfPatientsAssigned;
            return (basic + incomeFromPatients);    
        }
    }
}
