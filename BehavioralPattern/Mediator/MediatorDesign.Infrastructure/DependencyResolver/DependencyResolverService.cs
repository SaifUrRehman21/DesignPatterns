using MediatorDesign.Application.Contract.Repository;
using MediatorDesign.Application.Contract.Service;
using MediatorDesign.Infrastructure.Repository;
using MediatorDesign.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorDesign.Infrastructure.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
