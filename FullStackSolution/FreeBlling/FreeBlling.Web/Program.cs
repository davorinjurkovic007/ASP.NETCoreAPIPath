using FreeBlling.Web;
using FreeBlling.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailService>();

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

app.Run();
