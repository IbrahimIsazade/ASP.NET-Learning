using Microsoft.EntityFrameworkCore;
using WebApplicationTask15.Models.Entities;

namespace WebApplicationTask15.Models.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Country> Countries { get; set; }
    }
}
