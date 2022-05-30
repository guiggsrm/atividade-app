using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProTask.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add context
            ContextInjection.AddContext(services, configuration);
            // Add repositories
            RepositoriesInjection.AddRepositories(services);
            // Add services
            ServicesInjection.AddServices(services);
            // Add mapper
            MapperInjection.AddMapper(services);

            return services;
        }
    }
}