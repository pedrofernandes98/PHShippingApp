using Microsoft.Extensions.DependencyInjection;
using PHShippingApp.Application.Services;
using PHShippingApp.Application.Services.Interfaces;

namespace PHShippingApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAplicationServices();

            return services;
        }

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingServiceService, ShippingServiceService>();

            return services;
        }
    }
}
