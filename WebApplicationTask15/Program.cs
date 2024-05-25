using Microsoft.EntityFrameworkCore;
using WebApplicationTask15.Models.DataContexts;

namespace WebApplicationTask15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseInMemoryDatabase("StudentsDb");
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(name:"default", pattern:"{controller=countries}/{action=index}/{id?}");

            app.Seed();

            app.Run();
        }
    }
}
