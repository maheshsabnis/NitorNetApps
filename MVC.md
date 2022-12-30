# ASP.NET MVC 5 (.NET Framework)

Project Folders
1. App_Start
	- Contains Static classes for
		- Routing
		- Action Filters
		- JS and CSS Bundles
2. App_Data	
	- COntains Data files
		- .mdf for SQL Database File
		- .xml/.json files
3. COntent
	- All CSS Files
4. fonts
	- Application Fonts
5. Scripts
	- jQUery Files those will be loaded in browser
6. Models
	- All Business Classes for APplication as well as Data Access Classes
7. Controllers
	- COntains MVC COntrollers
	- Each Controller has Action Methods for Http Get and Http Post request
8. Views
	- COntains Sub-Folders having names mathing with the name of the controller class
		- e.g. If COntroller NAme is 'HomeController', then the folder name will be 'Home'
		- THis sub-folder contains views matching for each action method from the controller
		- e.g.
			- IF Action Method is 'Index' the View NAme will be Idnex.cshtml

# MVC COncepts
	- Routing
		- It is a dictionary ttah contains URLs those matched with following Template
			- {controller}/{action}/{id}
				- controller :- Name of Controller class
				- action : NAme of Action Method of the Controller
				- id: The 'int' parameter to actio method
		- e.g.
			- If the Request URL is as follows
				- https://localhost:1234/Home/About
				- Request for 'About' action method from 'Home' Controller
	- HttpRequest --- GLobal.asax --- Application_Start() method --- THis initialize the ROuting table with Route Expressions
	- Action Filters
		- Add-On objects added in MVC Request Processing(?) for VAlue added execution
			- Security
			- Exception
			- LOgging
			- ... any other custom domain specific processing
	- Scaffolding
		- Controllers Scaffolding
			- Each COntroller class ends with name 'Controller'
			- When the Http Request is made to contrller, this world will be filtered out by routing
		- View Scaffolding
			- Generate Views by Right-CLiekcing on Each Action method
				- Right-CLick --- 'Add View'
			- Strongly-Typed Views
				- THey accepts Model class to Generate UI using Html Helper methods
				- Each View has the Template
					- Index aka List
						- It accepts IEnumerable of Model class to show COllection or List of Data on View 
					- Create
						- Accepts an EMpty Model to generate 'Text' Elements to accept data from ENd-User
					- Edit	
						- Accepts an  Model with Vlues to edit and to generate 'Text' Elements to accept modified data from ENd-User
					- Delete
						- Accepts and  Model with data to generate 'LAbels' Elements to show read-only data that can be deleted
					- Details
						- Accepts and  Model with data to generate 'LAbels' Elements to show read-only data 
					- Empty 
						- PAss any Model and design your own UI for it
				- Page View
					- Execute as a PAge
				- Partial View
					- Re-Usable View inside the PAge View
			- Views
				- Views having capability to integrate with JavaScript Lib and/or framework
	- COntroller
		- EMpty MVC Controller
		- MVC Controller with Read/Write Actions
		- MVC Cotroller with REad/Write Action with Views using ENtityFramework
		- The 'Controller' base class
			- THis class implements INterfaces
				- IExceptionFilter
					- For Exception Handling inside Controller
					- OnException()
				- IResultFilter
					- For executing the Response Object when action method is executed
					- OnExecuteResult()
				- IActionFilter
					- For Custom Action Filter
					- OnActionExecuting()
					- OnActionExecuted()
					- OnResultExecuting()
					- ONResultExecuted()
				- IAuthorizationFilter and IAuthenticationFilter
					- For Hanadling Security
						- USer Management
						- Role MAnagement
					- OnAuthorize()
				- ICOntroller and IAsyncCOntroller
			- SOme Important Properties
				- ModelState
					- USed to validate the POsted data from CLient
				- RouteData
					- USed to Read the Controller NAme under Execution as well as the curently executing Action MEthod
				- User
					- Current LoggedIn USer
		- Controller Define 'ActionMethods()'
			- HttpGet
				- Accept Get Reques,Executed on Server and Generate View Response
				- All Acton Methods are HttpGet by DEfault
			- HttpPost
				- ACcepts Data from End-USer in Http Body
				- THis data MUST be validated before executing Post and Put calls
					- USe ModelState property
				- FInally either Exception will be thrown or success execution takes place
					- But this Always returns View, (either error view or success view)
			- Each Action  Method Returns 'ActionResult' type
				- ActionResult is Abstract class having followign derive types
					- ViewResult, returns View
					- EmptyResult, returns No Response
					- JavaScriptResult, returns JavaScript in View
					- JsonResult, returns Json data
					- FileContetResult, Open file on server, read its contents an return thos contents
					- FilePathResul, Open File on server and provides its path to client (Browser) so that file can be open in browser
					- FileStreamResult, Download file on client as a Stream
	- RAzor Veiws
		- New eb Engine to Scaffold Views in MVC Apps
		- .cshtml
			- C# Code with Html Helper UI Elements
		- Html Helper
			- Lightweight HTML Server-Side Elements they are executed on Server and generate HTML UI 
			- They performs 'Model-Binding'(?) using 'Lambda Expressions'
				- Model-Binding is 'Binding' Public Property of Model class with HTML Helper UI Element so that when ENd-user enter data in this eleent, the Lambda expressio will eveluat it and will save this value in Model object
			- The 'HtmHelper' class
						

# MVC Programming
1. Validations
	- System.ComponentModel.DataAnnotations.dll
		- ValidationAttribute
			- AN Abstract BAse class
				- bool IsValid(object val)
				- USed to check the Vaidation based on LOgic
		- RequiredAttribute, COmpareAttribute, StringLengthAttribute, RegExAttribute, etc.
2. Two-Types of Validators in Application
	- Data Validation
		- Generally implemeneted using DataAnnotations
	- Process BAsed Validations
		- They are occured when posted data is valid, but the application while processing the data
		- THis is Implemeneted using Exception Handling
		- We can redirect to Error View to show errors, this view can accept data using 'HandlerErrorInfo' class
			- This class has properties Fro ControllerNAme, ActionNAme, and Exception
		- Each Action Method can have Try--Catch block
		- Since Controller base class implements 'IExceptionFilter' interface, this provides 'OnException(ExceptionContext)' method
			- We can implement this method once and we can write exception handling logic onece for all acton method for the controller
			- In OnException, we can go to the Error View using 'ViewName' property of the ViewResult class, but we cannot pass the Model because 'Model' is read-only property
			- Insetad, we can eitther create a custom Error view page (other than Error.cshtml) and Pass data to view using 'ViewData' or 'ViewBag'
				- ViewData property of the type 'ViewDataDictionary', contains Key/Value pair of data that we want to ass from Action Method to View
				- ViewBag, is Dynmaic object which will be casetd to DynamicViewDataDictionary at runtime
		- USe ExceptionFilter to Handler Exceptions
			- HandleErrInfoAttribute class that is an Action Filter
			- Create Custom Exception Filter
3. Make sure that the Depednency COntainer is created for al external Dependencies those MVC app has
	- USe the Following package
		- Unity.Mvc5
		- Install it from 'Manage NuGet Packages'