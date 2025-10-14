
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoAPI.Data;
using ToDoAPI.Mappings;
using ToDoAPI.Repositories;
using ToDoAPI.Services;

namespace ToDoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<TokenService>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = builder.Configuration["Jwt:Key"];
                var issuer = builder.Configuration["Jwt:Issuer"];
                var audience = builder.Configuration["Jwt:Audience"];

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateAudience = true,
                    ValidAudience = audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // Database
            builder.Services.AddDbContext<SchoolDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repository and Services
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddAutoMapper(cfg => { }, typeof(StudentProfile).Assembly);
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
