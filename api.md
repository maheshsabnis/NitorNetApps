# ASP.NET Web API

1. ApiController class
	- Base class that contains following
		- ModelState for Model Validation
		- Filters for 
			- Authorization, Authentication, Exception, etc.
		- Result Methods
			- Ok
			- Notfound
			- COnfilict
			- BadRequest
			-.... and many more
2. IHttpActionResult
	- An interface type that represents a response from Http Action Methods from API COtroller class