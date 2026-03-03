using StudentAPI.Repositry;
using StudentAPI.Service;
using StudentAPI.Services;

namespace StudentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IClassesService, ClassesService>();

            builder.Services.AddScoped<IStudentRepositry, StudentRepositry>();
            builder.Services.AddScoped <IClassesRepositry, ClassesRepositry>();




            builder.Services.AddControllers();

            // Add Swagger/OpenAPI support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Enable middleware for Swagger JSON and UI
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