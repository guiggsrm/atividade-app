using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProTask.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add context
            services.AddContext(configuration);
            // Add repositories
            services.AddRepositories();
            // Add services
            services.AddServices();
            // Add mapper
            services.AddMapper();
            // Add identity
            services.AddIdentity(configuration);
            // Add JWT token
            services.AddJwt(configuration);

            return services;
        }
    }
}