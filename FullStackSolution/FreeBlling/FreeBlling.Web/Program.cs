using FluentValidation;
using FreeBilling.Data.Entities;
using FreeBlling.Web;
using FreeBlling.Web.Apis;
using FreeBlling.Web.Data;
using FreeBlling.Web.Data.Entities;
using FreeBlling.Web.Migrations;
using FreeBlling.Web.Services;
using FreeBlling.Web.Validators;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BillingDb") ?? throw new InvalidOperationException("Connection string 'FreeBllingWebContext' not found.");

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.AddDbContext<BillingContext>();

// This is working for client side, for MVC
builder.Services.AddDefaultIdentity<TimeBillUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<BillingContext>();

//This is for API endpoint
//builder.Services.AddIdentityApiEndpoints<TimeBillUser>(options =>
//{
//   options.SignIn.RequireConfirmedAccount = false;
//   options.Password.RequiredLength = 8;
//})
//   .AddEntityFrameworkStores<BillingContext>();

builder.Services.AddAuthentication()
    .AddJwtBearer(cfg =>
    {
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"] ?? ""))
        };
    });
//.AddBearerToken();

builder.Services.AddAuthorization(cfg =>
{
    cfg.AddPolicy("ApiPolicy", bldr =>
    {
        bldr.RequireAuthenticatedUser();
        bldr.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    });
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("api", cfg =>
    {
        cfg.RequireAuthenticatedUser();
        cfg.AddAuthenticationSchemes(IdentityConstants.BearerScheme);
    });

builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailService>();

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<TimeBillModelValidator>();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Allows us to serve index.html as the defautl webpage
//app.UseDefaultFiles();

// Allows us to serve files from wwwroot
app.UseStaticFiles();

// Add Routing
app.UseRouting();
//app.UseAuthentication();

// Add Auth middleware
app.UseAuthorization();

// Take a look under Pages folder and check for all razor pages
app.MapRazorPages();

//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync("<html><body><h1>Welcome to FreeBilling</h1></body></html>");
//});

TimeBillsApi.Register(app);
AuthApi.Register(app);

app.MapControllers();

//app.MapGroup("api/auth").MapIdentityApi<TimeBillUser>();

// No route was found, go to the vue app
app.MapFallbackToPage("/customerBilling");

app.Run();
