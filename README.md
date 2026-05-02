# ASP.NETCoreAPIPath

ASP.NET Core API path for practice



1. ASP.NET Core Web API Fundamentals

   -- GitHub repository: https://github.com/KevinDockx/AspNetCoreWebApiFundamentals

   -- Using Swager and scalar: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/using-openapi-documents?view=aspnetcore-10.0

   -- OpenAPI with Aspira, Swagger and Scalar primjer na početku: https://youtu.be/0qtwYT4n2CM?si=fWqgX8WOQMRws6zK

   -- .NET CLI overview: https://learn.microsoft.com/en-us/dotnet/core/tools/

   -- Lunch with CLI: dotnet run

 	Napomena: Samo pokreće http profile

      dotnet run --launch-profile https

  -- Routing in ASP.NET Core: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-10.0

  -- Solving problem in Swagger: https://www.reddit.com/r/dotnet/comments/1ouqvx5/have\_you\_seen\_swaggerui\_fail\_with\_route/

  -- Format response data in ASP.NET Core Web API: https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-10.0

  -- Fluent Validation: https://docs.fluentvalidation.net/en/latest/index.html

  -- JavaScript Object Notation (JSON) Patch : https://datatracker.ietf.org/doc/html/rfc6902

  -- HTTP PATCH Method: Partial Updates for RESTful APIs: https://blog.postman.com/http-patch-method/ Note: 416 error regarding PATCH

  -- Dependency injection in ASP.NET Core: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-10.0

  -- Logging in .NET and ASP.NET Core : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-10.0

  -- Third-party logging providers : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-10.0#third-party-logging-providers

&#x20; -- Manage JSON Web Tokens in development with dotnet user-jwts : https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-10.0\&tabs=windows

&#x20;    --	Examples of usage:

&#x09;...projectdirectory $> dotnet user-jwts create --help

        Default token: $> dotnet user-jwts create

&#x09;Key: dotnet user-jwts key --issuer https://localhost:7003

&#x09;-- taj Key prekopiramo u kod: Authentication:SecretForKey, i zatim pozovemo sljedeću komandu.

&#x09;Generated Token: dotnet user-jwts create --issuer https://localhost:7003 --audience cityinfoapi

&#x09;-- Token sa City claim: $> dotnet user-jwts create --issuer https://localhost:7003 --audience cityinfoapi --claim "city=Antwerp"

&#x20;       List of local tokens for the project: $> dotnet user-jwts list

&#x09;Return saved token with Id from previous command: $> dotnet user-jwts print d0edc01b

&#x20; -- Course tip: Securing ASP.NET Core with OAuth2 and OpenID Connect

&#x20; -- Depricated:: Test web APIs with the HttpRepl: https://learn.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-10.0\&tabs=windows

&#x20;    -- Examples of usage:

&#x20;       C:\\Users\\Borovnica $ dotnet tool install -g --prerelease Microsoft.dotnet-httprepl

&#x20;    Depricated: https://github.com/dotnet/HttpRepl/issues/701

&#x20;    Alternative:    command line tool and library for transferring data with URLs  => curl: https://curl.se/

&#x20; -- Use .http files in Visual Studio 2022: https://learn.microsoft.com/en-us/aspnet/core/test/http-files?view=aspnetcore-10.0

&#x20; -- Configure ASP.NET Core to work with proxy servers and load balancers: https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-10.0

&#x20; -- Introduction to Application Insights - OpenTelemetry observability: https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview?tabs=webapps

&#x20; -- What are managed identities for Azure resources?: https://learn.microsoft.com/en-us/entra/identity/managed-identities-azure-resources/overview



2\. Building a Web App with ASP.NET Core 10, MVC, Entity Framework, TailwindCSS, and Vue

&#x20;  -- aspnet-client-validation

&#x20;     https://www.jsdelivr.com/package/npm/aspnet-client-validation

&#x20;   -- Adding client-side validation to ASP.NET Core, without jQuery or unobtrusive validation

&#x20;      https://andrewlock.net/adding-client-side-validation-to-aspnet-core-without-jquery-or-unobtrusive-validation/

&#x20;   -- aspnet-client-validation

&#x20;      https://github.com/haacked/aspnet-client-validation/tree/main

&#x20;   -- ASP.NET Core 6 Razor Pages Fundamentals

&#x20;      https://app.pluralsight.com/ilx/video-courses/asp-dot-net-core-6-razor-pages-fundamentals/course-overview

&#x09;

