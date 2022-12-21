using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Event
{
    // 1. Define an Delegate
    // Rule: A Delegate whih will be used to declare an event MUST be 'void'
    // 
    public delegate void TransactionHandler(decimal amount);

    public class Banking
    {
        //2. Declare events

        public event TransactionHandler OverBalance;
        public event TransactionHandler UnderBalance;

        decimal NetBalance = 0;

        public Banking(decimal netBalance)
        {
            NetBalance = netBalance;
        }

        public void Deposit(decimal txAmount)
        {
            NetBalance+= txAmount;
            if(NetBalance > 100000)
            {
                // 3. Raise Event
                OverBalance(txAmount);
            }
        
        }
        public void Withdrawal(decimal txAmount)
        {
            NetBalance-= txAmount;
            if(NetBalance < 5000) 
            {
                // 3. Raise Event
                UnderBalance(txAmount);
            }
           
        }
        public decimal GetNetBalance() 
        {
            return NetBalance;
        }
    }

    /// <summary>
    /// This is the class that will be known by Banking class as well as the client
    /// </summary>
    public class EventListener
    {
        Banking banking;
        /// <summary>
        /// The EVent Listener is ready to listen
        /// Notifications from Banking class
        /// </summary>
        /// <param name="banking"></param>
        public EventListener(Banking banking)
        {
            this.banking = banking;
            // Create a Notification method that will be executed
            // when the banking class raise an event
            banking.OverBalance += Banking_OverBalance;
            banking.UnderBalance += Banking_UnderBalance;
        }

        private void Banking_UnderBalance(decimal amount)
        {
            Console.WriteLine("Please maintain Minimum balance");
        }

        private void Banking_OverBalance(decimal amount)
        {
            decimal netBalane = banking.GetNetBalance();
            decimal taxableAmt = netBalane - 100000;
            decimal tax = taxableAmt * Convert.ToDecimal(0.15);
            Console.WriteLine($"Der Sir, YOur Net Balance is Rs.{taxableAmt}/- more than Rs 100000/- so please pay tax of Rx.{tax}/- else Mr. Modi will catch you");
        }
    }
}
