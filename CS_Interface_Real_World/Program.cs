// See https://aka.ms/new-console-template for more information
using CS_Interface_Real_World;

Console.WriteLine("INterface In Real WOrld");

DbBridge bridge= new DbBridge();

IDbAccess dbAccess = bridge.GetDbAccess("Sql");

dbAccess.GetDbConnection();

dbAccess = bridge.GetDbAccess("MySql");
dbAccess.GetDbConnection();


Console.ReadLine(); 
