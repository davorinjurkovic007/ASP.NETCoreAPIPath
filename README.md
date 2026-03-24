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

&#x09;

