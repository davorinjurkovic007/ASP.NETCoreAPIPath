using FreeBlling.Web;
using FreeBlling.Web.Data;
using FreeBlling.Web.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.AddDbContext<BillingContext>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailService>();

builder.Services.AddControllers();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Allows us to serve index.html as the defautl webpage
app.UseDefaultFiles();

// Allows us to serve files from wwwroot
app.UseStaticFiles();

// Take a look under Pages folder and check for all razor pages
app.MapRazorPages();

//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync("<html><body><h1>Welcome to FreeBilling</h1></body></html>");
//});

app.MapControllers();

app.Run();
