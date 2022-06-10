using Microsoft.Extensions.DependencyInjection;
using ProTask.Domain.Interfaces;
using ProTask.Infra.Data.Repositories;

namespace ProTask.Infra.Ioc
{
    public static class RepositoriesInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TasksRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}