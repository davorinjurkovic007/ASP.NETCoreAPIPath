using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.MicrosoftExtensions;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

// Example how to manipulate Error responses
//builder.Services.AddProblemDetails(options =>
//{
//    options.CustomizeProblemDetails = ctx =>
//    {
//        ctx.ProblemDetails.Extensions.Add("additionalInfo", "Additional info example");
//        ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName);
//    };
//});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });

    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Before .NET6+ 
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); 
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World!");
//});

app.Run();
