using Microsoft.EntityFrameworkCore;
using OganiWebApp.Models.Entities;

namespace OganiWebApp.Models.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public override int SaveChanges()
        {
#warning todo: created-at

            return base.SaveChanges();
        }
    }
}
