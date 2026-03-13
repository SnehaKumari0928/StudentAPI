using Scalar.AspNetCore;
using StudentAPI.Repositry;
using StudentAPI.Service;
using StudentAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

                    };



                });
                



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