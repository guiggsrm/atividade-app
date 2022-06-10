using Microsoft.Extensions.DependencyInjection;
using ProTask.Application.Interfaces;
using ProTask.Application.Services;
using ProTask.Domain.Account;
using ProTask.Infra.Data.Identity;

namespace ProTask.Infra.Ioc
{
    public static class ServicesInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            // Identity services
            services.AddScoped<IAuthenticate, AuthenticateManager>();
            services.AddScoped<ISeedUserRoleService, SeedUserRoleService>();

            // Security services
            services.AddScoped<ITokenService, TokenService>();

            // Application services
            services.AddScoped<ITasksService, TasksService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}