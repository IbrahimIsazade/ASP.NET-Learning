using WebApplicationTask15.Models.Entities;

namespace WebApplicationTask15.Models.DataContexts
{
    public static class DataSeed
    {
        internal static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();

                var list = new[]
                {
                    new Country { Id = 1, Name = "Azerbaijan", Code = "+994"},
                    new Country { Id = 2, Name = "United States", Code = "+1" },
                    new Country { Id = 3, Name = "Russia", Code = "+7" }
                };

                db.Countries.AddRange(list);
                db.SaveChanges();
            }

            return app;
        }
    }
}
