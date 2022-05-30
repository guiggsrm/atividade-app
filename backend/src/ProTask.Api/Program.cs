using System.Text.Json.Serialization;
using ProTask.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(option => {
                            option.AddDefaultPolicy(policity => {
                                                    policity.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                                                   //policity.AllowAnyOrigin()
                                                   /*policity.WithOrigins("http://localhost:3000/",
                                                                        "localhost:3000/",
                                                                        "https://localhost:7074/",
                                                                        "localhost:7074/")*/
                                                   .AllowAnyHeader()
                                                   .WithMethods("GET", "POST", "DELETE", "PUT")
                                                   .AllowCredentials();
                                             });
                        });

builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
