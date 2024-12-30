using Microsoft.EntityFrameworkCore;
using Shop_QuanAo.Models;

namespace Shop_QuanAo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DbContext for Oracle database connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map controllers
            app.MapControllers();

            // Configure the route for admin area (if using areas)
            app.MapControllerRoute(
                name: "admin",
                pattern: "api/admin/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
