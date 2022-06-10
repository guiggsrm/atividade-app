using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProTask.Infra.Ioc
{
    public static class SwaggerInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s => {
                // Define security
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using  the Bearer Scheme.\r\n\r\n" +
                                  "Enter a Bearer [space] and then your token in the text input bellow.\r\n\r\n" +
                                  "Example: \"Bearer 123asdaweweae\" "
                });
                // Define configurations
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme(){
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}