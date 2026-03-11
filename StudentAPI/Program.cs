using Scalar.AspNetCore;
using StudentAPI.Repositry;
using StudentAPI.Service;
using StudentAPI.Services;

namespace StudentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // stes up the default application configuration,
            //logging and dependency injection container.
            // kestrel server 
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IClassesService, ClassesService>();

            //add services to the container
            //add service for controllers to the specified IServiceCollection.
            builder.Services.AddScoped<IStudentRepositry, StudentRepositry>();
            builder.Services.AddScoped <IClassesRepositry, ClassesRepositry>();




            builder.Services.AddControllers();

            // Add Swagger/OpenAPI support
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Enable middleware for Swagger JSON and UI
                //app.UseSwagger();
                //app.UseSwaggerUI();

                app.MapOpenApi();
                app.MapScalarApiReference();

            }

            // Any request HTTP pipeline middleware that is added to the application
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}