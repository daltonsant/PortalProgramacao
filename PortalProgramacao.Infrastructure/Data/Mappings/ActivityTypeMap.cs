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

            builder.HasData(new List<ActivityType>(){
                new ActivityType(){
                    Id = 1,
                    Name = "Preventiva SE",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 2,
                    Name = "Preventiva LT",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 3,
                    Name = "Inspeção SE",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 4,
                    Name = "Inspeção LT",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 5,
                    Name = "Corretiva SE",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 6,
                    Name = "Corretiva LT",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 7,
                    Name = "Expansão SE",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 8,
                    Name = "Expansão LT",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 9,
                    Name = "Comissionamento SE",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 10,
                    Name = "Comissionamento LT",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 11,
                    Name = "Corretiva Aut",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 12,
                    Name = "Preventiva Aut",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 13,
                    Name = "DESC",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 14,
                    Name = "Apoio a UTD/UTEPs",
                    CreatedDate = DateTime.Now
                },
                new ActivityType(){
                    Id = 15,
                    Name = "Transporte",
                    CreatedDate = DateTime.Now
                }
            });

            builder.ToTable("ActivityTypes");
        }
    }
}
