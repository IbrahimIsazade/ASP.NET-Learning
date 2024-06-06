using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OganiWebApp.Models.Entities;

namespace OganiWebApp.Models.Contexts.Configurations
{

    public class SubscribeEntityTypeConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Subscribers");
        }
    }

}
