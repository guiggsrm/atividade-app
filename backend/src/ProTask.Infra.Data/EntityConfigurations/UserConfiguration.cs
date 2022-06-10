using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProTask.Infra.Data.Identity;

namespace ProTask.Infra.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Lang).HasMaxLength(5).IsRequired(true).HasDefaultValue("en");
        }
    }
}