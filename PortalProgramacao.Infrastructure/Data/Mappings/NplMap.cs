using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Entities.Regions.Sectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class NplMap : IEntityTypeConfiguration<Npl>
    {
        public void Configure(EntityTypeBuilder<Npl> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(16);
            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.Name).HasMaxLength(256);

            builder.HasOne(e => e.Sector).WithMany(x => x.Npls);

            builder.HasMany(e => e.EmployeesInNpl).WithOne(x => x.Npl);
            builder.HasMany(e => e.Activities).WithOne(x => x.Npl);

            builder.ToTable("Npls");
        }
    }
}
