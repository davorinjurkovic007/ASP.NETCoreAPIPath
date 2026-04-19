using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using CityInfo.API;
using CityInfo.API.DbContexts;
using CityInfo.API.Profiles;
using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Pročitati za dalje:
// ASP.NET Core Dropped Swagger - Here's What Replaced It 
// https://codewithmukesh.com/blog/dotnet-swagger-alternatives-openapi/
// 
// Generate OpenAPI documents
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-10.0&tabs=visual-studio%2Cvisual-studio-code
//
// Building Beautiful API Documentation with Scalar and Multi-Version Support in .NET 10 
// https://www.dotnetmastery.com/Blog/Details?slug=scalar-api-documentation-multi-version-dotnet10
//
// Building Professional, Modern API Documentation in .NET Core with Scalar
// https://oussamasaidi.com/en/building-professional-modern-api-documentation-in-net-core-with-scalar/
//
// Managing OpenAPI Specifications with Backend For Frontend and Swagger UI 
// https://duendesoftware.com/blog/20250430-managing-openapi-specifications-with-backend-for-frontend-and-swagger-ui

// Primjer za pogledati kako se radilo prije: API Versioning in ASP.NET Core
// https://www.milanjovanovic.tech/blog/api-versioning-in-aspnetcore

// API Versioning in ASP.NET Core
// https://int.nextwave.education/api-versioning-in-asp-net-core/

// API Creation Best Practices in .NET Core — Lessons from the Field
// https://np4652.medium.com/api-creation-best-practices-in-net-core-lessons-from-the-field-46038abf3d38

// API Explorer Options
// https://github.com/dotnet/aspnet-api-versioning/wiki/API-Explorer-Options#format-group-name

// C# .net Swagger API Versioning – Show versions in your Swagger page
// https://briancaos.wordpress.com/2022/10/14/c-net-swagger-api-versioning-show-versions-in-your-swagger-page/

// Verzioniranje OpenAPI + SwaggerUI
//  https://learn.microsoft.com/en-us/answers/questions/5840367/net-10-issues-with-openapi


var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();

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
builder.Services.AddOpenApi("v0.1", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "ASP.NET Core Web API v0.1",
            Version = "v0.1",
            Description = "ASP.NET Core Web API with JWT authentication. " +
                "Target Framework is .NET 10. " +
                "Built‑in OpenAPI + SwaggerUI are used."
        };

        // Add Security Scheme (JWT Bearer）
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??=
            new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes.Add("Bearer",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Please enter token"
            });

        // Add Security Requirement
        document.Security ??= new List<OpenApiSecurityRequirement>();
        document.Security.Add(
            new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            }
        );

        return Task.CompletedTask;
    });
});

builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "ASP.NET Core Web API",
            Version = "v1",
            Description = "ASP.NET Core Web API with JWT authentication. " +
                "Target Framework is .NET 10. " +
                "Built‑in OpenAPI + SwaggerUI are used."
        };

        // Add Security Scheme (JWT Bearer）
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??=
            new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes.Add("Bearer",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Please enter token"
            });

        // Add Security Requirement
        document.Security ??= new List<OpenApiSecurityRequirement>();
        document.Security.Add(
            new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            }
        );

        return Task.CompletedTask;
    });
});
builder.Services.AddOpenApi("v2", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info = new OpenApiInfo
        {
            Title = "ASP.NET Core Web API v0.1",
            Version = "v2",
            Description = "ASP.NET Core Web API with JWT authentication. " +
                "Target Framework is .NET 10. " +
                "Built‑in OpenAPI + SwaggerUI are used."
        };

        // Add Security Scheme (JWT Bearer）
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??=
            new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes.Add("Bearer",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Please enter token"
            });

        // Add Security Requirement
        document.Security ??= new List<OpenApiSecurityRequirement>();
        document.Security.Add(
            new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", document)] = []
            }
        );

        return Task.CompletedTask;
    });
});

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif
builder.Services.AddSingleton<CitiesDataStore>();

builder.Services.AddDbContext<CityInfoContext>(dbContextOptions 
    => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CityProfile>();
    cfg.AddProfile<PointOfInterestProfile>();
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeFromAntwerp", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("city", "Antwerp");
    });
});

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
}).AddMvc()
.AddApiExplorer(setupAction =>
{
    setupAction.GroupNameFormat = "'v'VVV";
    setupAction.SubstituteApiVersionInUrl = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi("/openapi/CityInfo.API.json");
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/openapi/CityInfo.API.json", "My API v1");
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
        options.SwaggerEndpoint("/openapi/v2.json", "My API v2");
        options.SwaggerEndpoint("/openapi/v0.1.json", "My API v0.1");

       
    });

    app.UseReDoc(options =>
    {
        //options.SpecUrl("/openapi/CityInfo.API.json");
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference(options =>
    {
        options
            .WithTheme(ScalarTheme.BluePlanet);

        options
            .AddDocument("v1", "API Version 1.0", "/openapi/v1.json", isDefault: true)
            .AddDocument("v2", "API Version 2.0", "/openapi/v2.json")
            .AddDocument("v0.1", "API Version 0.1", "/openapi/v0.1.json");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

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
