
using HealthcareAPI.Database;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Repositories;
using HealthcareAPI.Services;

namespace HealthcareAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("HealthcareConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Enable Swagger in Development/Production
            //app.UseSwagger();
            //app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
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
