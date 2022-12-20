using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Abstraction_Encapsuation.Models
{
    /// <summary>
    /// ENtity class
    /// </summary>
    public class Staff
    {
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? StaffCategory { get; set; }
        public string? Degree { get; set; }
        public double BasicPay { get; set; }
    }
}
