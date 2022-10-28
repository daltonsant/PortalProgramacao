using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalProgramacao.Domain.Entities.Regions.Sectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class RegionMap : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(16);
            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.Name).HasMaxLength(256);

            builder.HasMany(e => e.Npls).WithOne(x => x.Sector);

            builder.ToTable("Sectors");
        }
    }
}
