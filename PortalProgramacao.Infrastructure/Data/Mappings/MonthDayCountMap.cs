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
    public class MonthDayCountMap : IEntityTypeConfiguration<MonthDayCount>
    {
        public void Configure(EntityTypeBuilder<MonthDayCount> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.Year).IsRequired();
            builder.Property(e => e.Month).IsRequired();
            builder.Property(e => e.NumberOfDays);

            builder.ToTable("MonthDayCounts");
        }
    }
}
