# EF Core PAckages

1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer
3. Microsoft.EntityFrameworkCore.Design
4. Microsoft.EntityFrameworkCore.Tools

# Use of CLI
- INstalling PAckage for a project
	- Open Command Prompt
	- Navigate to Project Folder (to bin)
	- Run Following command
		- dotnet add package [PACKAGE-NAME] -v [VERSION-NUMBER]
		- e.g.
		 - dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0
# Project Structure
	- Program.cs
		- AN ENtrypoint to ASP.NET Core App
# ASP.NET Core COnfigurations
	- No Web.Config File No Globala.asax
	- instead use 'appsettings.json'
	- Settings from appsettings.josn are read using 'ICofiguration' interface
		- builder.Configuration
# ASP.NET Core DI Container
	- WebApplicationBuilder.Services
		- THis is an 'IServiceCollection' inteface Type
		- THis is used to REgister all dependencies as 'Service' in current application so that they can be used in HTTP Pipeline	
		- THis interface uses 'ServiceDescriptor' class to manage the Registeration (THis is default DI Container class)
			- Singleton()
				- The Object will be reistered once and a single instance wil be availabel for all requests from all sessions
				- Global Activation
				- IServiceCollection.AddSingeton()
			- Scopped
				- THe object will be register in DI and its new instance will be available for each new session
				- Once the session is closed, this object will be released
				- A 'Statfull' activation
				- IServiceCollection.AddScopped()
			- Transient()
				- The object will be registered and for each new request the objet instance will be created
				- Once the response for the request is generated thos object will be released
				- A 'Stateless' activation
				- IServiceCollection.AddTransient()

# EF Core
1. MAke sure that the dornet ef tool is install on the machine after the SDK is instaled
	- dotnet tool install --global dotnet-ef
2.Database First
	- Scaffold the Model classes from Database aka generate DbContext class and Model classes (entities) from mdatabase
	- MAke sure that following packages are already installed for the Project (EF Core PAckages)
		-   1. Microsoft.EntityFrameworkCore
			2. Microsoft.EntityFrameworkCore.SqlServer
			3. Microsoft.EntityFrameworkCore.Design
			4. Microsoft.EntityFrameworkCore.Tools
	- Run the Following command from Command Prompt from the Project folder (to bin) 
		- dotnet ef dbcontext scaffold "[CONNECTION-STRING]" [PROVIDER] -o Models
		- e.g.
			- dotnet ef dbcontext scaffold "[CONNECTION-STRING]" Microsoft.EntityFrameworkCore.SqlServer -o Models
3. Code First
	- Install EF COre PAckages
	- Create Model classes aka Entity Classes with Annotations e.g. [Key]
	- Create DbContext class 
		- Note: MAke Sure that it has the Parameterrized COnstructor that accepts 'DbContextOptionsBuilder' parameter, pass this parameeter to Base class
			- ctor(DbContextOptions<DbContext> options):base(options)
		- This is needed for REgistering DbContext in the DI COntainer 	
	- Run the FOllowing COmmand to Generate Migrations
		- dotnet ef migrations add [MIGRATION-NAME] -c [NAmeSPace.DbContextClass]
			- This command will create Migration Class
	- Run the Following COmmand to Runt MIgrations to Generate Database and Tables
		- dotnet ef database update  -c [NAmeSPace.DbContextClass]
4. EF COre Recommendations
	- USe Async programming
		- dbcontext.entities.AddAsync(); | AddRangeAsync()
		- FindAsync()
		- Remove()
		- ToListAsync()
			- THis method needs Microsoft.EntityFrameworkCore namespace refferred in Code
			
5. Views Concept
	- HTml Helpers for BAckward Compatibility
	- Tag-Helpers new in ASP.NET Core
		- Lightweight Attribute classes those are added to HTML Tags (Elements) to set their behavior
	- asp-for
		- applied to Editable elements to bind the public property of Model class with HTML UI for Data Binding
	- asp-action
		- Bind the action method to HTML hyperlink (aka anchor) tag
		- HTTP Request for Action MEthod
	- asp-controller
		- Bind the controller to HTML hyperlink (aka anchor) tag
		- HTTP Request for the controller
	- asp-items
		- Bind with the HTML Select element to generate the options based on collection received from action method
	- asp-validation-for
		- Associate Model Validation applied on Model class property with the HTML Element
	- asp-route-id
		- For Routing