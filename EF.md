# EntityFramework
1. Object Relational Mapping Technology (ORM)
	- Database First aka DB FIrst
		- The Model (ENtity Classes) and Data Access Layer is generated based on Database Schema
		- THis is used when the DB is Production Ready or we are working on Migration Application e.g. .NET older vrsion to .NET 4.x+
	- Code-First 
		- We create Domain / Logic Model with ENtity classes and then the DB is generated from it
		- Use this when app is deign from scratch and no database is fixed
2. EntityFramework (EF) Object Model
	- DbContext, is the base class for EF
		- Manage DB Connection
		- Manage the CLR Class /  Entity Class mapping with Database Table using 'DbSet<T>' class
		- Manage Db Transactions using 'SaveChanges()' method
	- DbSet<T>
		- Class tha represents Mapping of Entity Class with DB Table
		- T is the ENtity class namd that is mapped with Table Name 'T'
		- DbSet represents the cursor that maped with data in the table (aka select operations)
		- Methods
			- Add(), to add a single record
			- AddRange(), to add multiple records
			- Remove(), to delete  record

3. pseduo code
	- COsider that 'ctx' is an instance of DbContext
	- COnsider 'Employee' is name of the Table mapped as 'DbSet<Employee>'
		- DbSet<Employee> Mapping will be as 'Employees'

	- To Read all Records usin DbSet
		- var Emps = ctx.Employees.ToList();
	- To FInd a REcord based on Primary Key
		- var Emp = ctx.Employees.Find(PRIMARY-KEY-VALUE);
	- To Append /  Add new record
		- Create an Instance of Employee (ENtity Class) and set its property values
			- var Emp = new EMployee();
			- Emp.EmpNo=101; EMp.EmpName="FFF";
		- Add the 'Emp' in 'Employees'
			- ctx.Employees.Add(Emp);
		- Commit the Transaction
			- ctx.SaveChanges();
	- To Update a Record 
		- Search Record usig Primary Key 
			- var Emp = ctx.Employees.Find(PRIMARY-KEY-VALUE);
		- Update its Values
			- Emp.EmpName = "FFFFFFF";
		- Commit Transaction
			- ctx.SaveChanges();
	- To Delete Record
		- Search Record usig Primary Key 
			- var Emp = ctx.Employees.Find(PRIMARY-KEY-VALUE);
		- Remove Record
			- ctx.Employees.Remove(Emp);
		- Commit Transactions
			- ctx.SaveChanges();

4. USing COde First Approach
	- INstall 'EntityFramework' PAckage in the Project
	- IN App.COnfig file (or Web.COnfig file for MVC, ASP.NET and API projects of .NET Framework) wirh COnnection String in it
		- NuGet\Install-Package EntityFramework -Version 6.4.4
	- CReate ENtity Class(es)
		- If multiple entities with relationships then establish relationships
	- CReate DbContext class and using DbSet<T> define DbSet TYpe Propeties
	- ENable The project for Migrations
		- OPen the Tools -> Nuget Package Manager -> Package Manager Console
		- Run FOllowing ommands
			- Enable-Migration
				- THis will make sure that the Current project will be enable for Code-First feature of EF
			- Add-Migration
				- THis command will generate following file
					- [Migration-Name].cs
						- This will contains C# script to generate Table(s) from ENtity Class(es)
			- Update-Database
				- THis will execute a Migration Script to generate Database and Tables
				- THis will read the Connection string from App.COnfig file to conenct to Cnnect to SQL Sever and create database and Table(s) in it