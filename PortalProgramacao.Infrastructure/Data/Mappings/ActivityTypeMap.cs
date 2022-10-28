using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityType = PortalProgramacao.Domain.Entities.Activities.Type;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class ActivityTypeMap : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
           
            builder.Property(e => e.Name).HasMaxLength(256);

            builder.HasMany(e => e.Activities).WithOne(x => x.Type);

            builder.ToTable("ActivityTypes");
        }
    }
}
