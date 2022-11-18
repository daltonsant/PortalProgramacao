using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Entities.Regions.NPLs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalProgramacao.Domain.Entities.Activities;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            builder.Property(e => e.Key);
            builder.Property(e => e.Status);
            builder.Property(e => e.Title);
            builder.Property(e => e.Place);
            builder.Property(e => e.MenHour);
            builder.Property(e => e.HeadCount);
            builder.Property(e => e.Hours);
            builder.Property(e => e.ComuteTime);
            builder.Property(e => e.OsNote);
            builder.Property(e => e.PlanedDate);
            builder.Property(e => e.ProgramedDate);
            builder.Property(e => e.DueDate);
            
            builder.ToTable("Activities");
        }
    }
}
