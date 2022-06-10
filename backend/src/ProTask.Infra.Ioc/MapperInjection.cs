using Microsoft.Extensions.DependencyInjection;
using ProTask.Application.Mappings;

namespace ProTask.Infra.Ioc
{
    public static class MapperInjection
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}