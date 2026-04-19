using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Version = "10.0";
        document.Info.Title = "Demo .NET 10 API";
        document.Info.Description = "This API demonstrated OpenAPI customization in a .NET 10 projects.";
        document.Info.TermsOfService = new Uri("https://index.hr");
        document.Info.Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "Luka Poriluk",
            Email = "luka@poriluk.hr",
            Url = new Uri("https://tportal.hr")
        };

        document.Info.License = new Microsoft.OpenApi.OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        };

        // You can also customize server URLs, security definitions, and schemas if needed:
        document.Servers?.Add(new Microsoft.OpenApi.OpenApiServer
        {
            Url = "https://api.codewithmukesh.com/v1",
            Description = "Production Server"
        });

        return Task.CompletedTask;
    });
});

builder.Services.AddOpenApi("v2", options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Version = "10.0";
        document.Info.Title = "Demo V2 .NET 10 API";
        document.Info.Description = "This API demonstrated OpenAPI customization in a .NET 10 projects. V2 Version";
        document.Info.TermsOfService = new Uri("https://index.hr");
        document.Info.Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "Luka Poriluk",
            Email = "luka@poriluk.hr",
            Url = new Uri("https://tportal.hr")
        };

        document.Info.License = new Microsoft.OpenApi.OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        };

        // You can also customize server URLs, security definitions, and schemas if needed:
        document.Servers?.Add(new Microsoft.OpenApi.OpenApiServer
        {
            Url = "https://api.codewithmukesh.com/v1",
            Description = "Production Server"
        });

        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Swagger V1");
        options.SwaggerEndpoint("/openapi/v2.json", "Swagger V2");
     });

    app.MapScalarApiReference(options =>
    {
        options
        .WithTheme(ScalarTheme.DeepSpace);

        options.Title = "Royal Villa API";

        options
            .AddDocument("v1", "API Version 1.0", "/openapi/v1.json", isDefault: true)
            .AddDocument("v2", "API Version 2.0", "/openapi/v2.json");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
