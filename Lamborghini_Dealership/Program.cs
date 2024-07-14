
using Lamborghini_Dealership.Data;
using Lamborghini_Dealership.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Lamborghini_Dealership
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
            builder.Services.AddSingleton<MongoDBSettings>();
            builder.Services.AddScoped<IMongoDBService, MongoDBService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lamborghini Dealership API",
                    Description = "An API that simulates a Lamborghini dealership. This project was developed so that programmers have an API ready for consumption and training.",
                    Contact = new OpenApiContact
                    {
                        Name = " - Victor Augusto Martinez",
                        Email = "yvictoraugustomartinez@gmail.com"
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}