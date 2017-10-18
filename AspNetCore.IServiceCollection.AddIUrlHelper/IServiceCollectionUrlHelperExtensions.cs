using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.IServiceCollection.AddIUrlHelper
{
    public static class IServiceCollectionUrlHelperExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddUrlHelper(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddScoped(it =>
                    it
                        .GetRequiredService<IUrlHelperFactory>()
                        .GetUrlHelper(it.GetRequiredService<IActionContextAccessor>().ActionContext));
            return services;
        }
    }
}