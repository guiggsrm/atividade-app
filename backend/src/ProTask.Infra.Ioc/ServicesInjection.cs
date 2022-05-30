using Microsoft.Extensions.DependencyInjection;
using ProTask.Application.Interfaces;
using ProTask.Application.Services;

namespace ProTask.Infra.Ioc
{
    public static class ServicesInjection
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITasksService, TasksService>();
        }
    }
}