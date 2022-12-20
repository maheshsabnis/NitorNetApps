using CS_Inhertence.Logic;
using CS_Inhertence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Inhertence.Accountant
{
    public class Accountancy
    {
        /// <summary>
        /// The Out patameter initial value will be passed by caller
        /// The metho will update it and return udated value back to caller
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="total"></param>
        /// <param name="net"></param>
        /// <param name="tax"></param>
        public void PrintTotalIncomeNetIncomeTax(StaffLogic logic, Staff staff, out double total, out double net, out double tax)
        {
            total = logic.CalcuateIncome(staff);
            tax = total * Convert.ToDouble(0.1);
            net = total - tax;
        }
    }
}
