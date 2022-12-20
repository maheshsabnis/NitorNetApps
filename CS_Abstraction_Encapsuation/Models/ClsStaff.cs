using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Abstraction_Encapsuation.Models
{
    internal class ClsStaff
    {
        // Encapsulation of Information
        int _StaffId;
        string? _StaffName;
        string _StaffCategory = string.Empty;
        double _BasicPay;

        List<object> staffs = new List<object>();   

        /// <summary>
        /// Abstratcion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="pay"></param>
        public void RegisterStaff(int id, string name, string category, double pay)
        {
            _StaffId= id;
            _StaffName= name;
            _StaffCategory= category;
            _BasicPay= pay;

            // Create a Anonymous Object on the fly for storing information of the Staff
            // in this object (C# 2.0)
            var staff = new { StaffId = _StaffId, StaffName = _StaffName, StaffCategory = _StaffCategory, BasicPay = _BasicPay };

            staffs.Add(staff);
        }

        public List<object> GetStaffs() 
        {
            return staffs;
        }
    }
}
