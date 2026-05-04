// How to Integrate Tailwind CSS on an ASP.NET MVC Web Application
// https://youtu.be/6xcusQFp9EU?si=3JrHlAekrG-S38tA

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();


app.Run();
