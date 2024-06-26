// Code generated by DevUp technologies, 11/12/2023 17:23:46
using InventoryWApi.Middleware;

namespace InventoryWApi.Extensions
{
    public static class ServiceExtensions
    {
        public static IApplicationBuilder ConfigureServices(this IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health");
            return app.UseMiddleware<InvokeActionMiddleware>();
        }
    }
}

