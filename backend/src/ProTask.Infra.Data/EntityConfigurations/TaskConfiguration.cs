using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProTask.Infra.Data.EntityConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Models.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
        {
            builder.ToTable("TbTask");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .HasMaxLength(100)
                .IsRequired(true);
            builder.Property(m => m.Description)
                .HasMaxLength(1000)
                .IsRequired(false);
            builder.Property(m => m.CreationDate).HasDefaultValueSql("getdate()");
        }
    }
}