using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Entities.Regions.NPLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalProgramacao.Domain.Entities.Employees;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.RegisterId).IsRequired().HasMaxLength(16);
            builder.HasIndex(e => e.RegisterId).IsUnique();

            builder.Property(e => e.Name).HasMaxLength(256);
            builder.HasMany(x => x.EnabledProcesses).WithOne(x => x.Employee);
            builder.HasMany(x => x.MonthDayCounts).WithOne(x => x.Employee);

            builder.ToTable("Employees");
        }
    }
}
