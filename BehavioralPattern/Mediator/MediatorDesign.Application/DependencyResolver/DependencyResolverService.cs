using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatorDesign.Application.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
