using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Abstraction_Encapsuation.Models;

namespace CS_Abstraction_Encapsuation.Logic
{
    public class StaffLogic
    {
        List<Staff> staffs = new List<Staff>();

        public void RegisterStaff(Staff staff)
        {
            staffs.Add(staff);
        }

        public List<Staff> GetStaffs()
        {
            return staffs;
        }
    }
}
