using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProTask.Domain.Models;

namespace ProTask.Infra.Data.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("TbClient");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            builder.Property(m => m.Situation)
                .IsRequired(true);
            builder.Property(m => m.CreationDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}