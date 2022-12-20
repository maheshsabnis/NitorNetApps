using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inhertence.Models
{
    public  class Staff
    {
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? ContactNo { get; set; }
        public double BasicPay { get; set; }
    }

    /// <summary>
    /// Class can have only one base class
    /// This provides Is-a Relationship
    /// </summary>
    public class Doctor : Staff
    {
        public int StaffId { get; set; }
        public int DoctorId { get; set; }
        public string Degree { get; set; }
        public string Specialization { get; set; }
        public int MaxPatientsPerDay { get; set; }
        public int MaxOPerationsPerDay { get; set; }
        public int PerPatientFeses { get; set; }
        public int PerOperationFees { get; set; }
    }

    public class Nurse : Staff
    {
        public int NoOfPatientsAssigned { get; set; }
        public int PayPerPatient { get; set; }
    }

}
