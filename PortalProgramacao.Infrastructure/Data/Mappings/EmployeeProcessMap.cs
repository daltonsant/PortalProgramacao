using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Entities.Regions.NPLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalProgramacao.Domain.Entities.Processes;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class EmployeeProcessMap : IEntityTypeConfiguration<EmployeeProcess>
    {
        public void Configure(EntityTypeBuilder<EmployeeProcess> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.Percentage);

            builder.ToTable("EmployeeProcesses");
        }
    }
}
