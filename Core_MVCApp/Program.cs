using Core_MVCApp.CustomFilters;
using Core_MVCApp.Data;
using Core_MVCApp.Models;
using Core_MVCApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// WebApplicatinBuilder object that is responsible for
// Creating collection of all those object used to design 
// the Current ASP.NET COre App
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is the Dependency Injection Container 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// REgister the EF COre in DI Container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // Create the EF COre Instance for SQL Server Database
    options.UseSqlServer(connectionString));

// Register the CompanyContext in DI COntainer
builder.Services.AddDbContext<CompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});


// REgister the Session Service Here
// The cache for SToring Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options => 
{
   options.IdleTimeout = TimeSpan.FromMinutes(20);
});


// REgister Service classes in DI
builder.Services.AddScoped<IService<Department,int>, DepartmentService>();

builder.Services.AddScoped<IService<Employee, int>, EmployeeService>();



// Default Error or Exception filter for Database Errors
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Service object for Identity for REgistering Following classes in
// DI Container
// 1. UserManager<IdentityUser>
// 2. SignInManager<IdentityUser>
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

// Service object for Identity for REgistering Following classes in
// DI Container
// 1. UserManager<IdentityUser>
// 2. SignInManager<IdentityUser>
// 3. RoleManager<IdenttyRole>
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI(); // THis will Accept Requests for Default Identity Pages


// REgister the AUthrization Serveric e for Defining Policies

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("ReadPolicy", policy =>
    {
        policy.RequireRole("Manager","Clerk", "Operator");
    });

    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("Manager", "Clerk");
    });
    options.AddPolicy("EditDeletePolicy", policy =>
    {
        policy.RequireRole("Manager");
    });
});


// THe Request Processing Object for MVC Controller, and Views
// THe folowing method also used to REgister Action Filters at global Level
builder.Services.AddControllersWithViews(options => 
{
    //options.Filters.Add(new LogFilterAttribute());
    //// the IModelMetadataProvider and ModelStateDIctionary
    //// will be resolved using MvcOPtions used by FIlters.Add()
    //options.Filters.Add(typeof(CustomExceptionFilterAttribute));
});
// For API Controllers
//builder.Services.AddControllers();
// For RAzor Views
// This is Mandatory when using AddIdentity<IdentityUser,IdentityRole>
// for Role BAsed Security
builder.Services.AddRazorPages();


// WebApplicationBuidler class that is used to Create the HTTP Pipeline
// and register Middlewares in it
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // Exception Filter
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // Http Security Context for Transport Security aka SSL
    app.UseHsts();
}
// Http ---> to Https
app.UseHttpsRedirection();
// REad FIles from wwwroot by defult
app.UseStaticFiles();
// STart Routing by Creating Rute Table
app.UseRouting();
// Configure the session Middleware 
app.UseSession();

// Identity Milddlewares
app.UseAuthentication();
app.UseAuthorization();
// Map the Request with MVC Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// MAp request with Razor Views
app.MapRazorPages();
// RUn the Application
app.Run();

