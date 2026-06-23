using FreeBlling.Web.Data;

namespace FreeBlling.Web.Apis
{
    public static class CustomerApi
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/api/customers", GetCustomers)
                .RequireAuthorization("ApiPolicy");
        }

        public static async Task<IResult> GetCustomers(IBillingRepository repository)
        {
            return Results.Ok(await repository.GetCustomers());
        }
    }
}
