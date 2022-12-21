// See https://aka.ms/new-console-template for more information
using CS_Event;

Console.WriteLine("Demo Events");

Banking bank = new Banking(80000);

// SUbscribe to Notification

EventListener evt = new EventListener (bank);   

bank.Deposit(70000);
Console.WriteLine($"Balance after Deposit {bank.GetNetBalance()}");
bank.Withdrawal(147000);
Console.WriteLine($"Balance after Withdrawal {bank.GetNetBalance()}");


Console.ReadLine(); 
