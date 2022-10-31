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

            builder.HasOne(e => e.Sector).WithMany(x => x.Npls).HasForeignKey(x => x.SectorId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.EmployeesInNpl).WithOne(x => x.Npl);
            builder.HasMany(e => e.Activities).WithOne(x => x.Npl);

            //1 - interior, 2 - litoral, 3 - metropolitano
            builder.HasData(new List<Npl>(){
                new Npl(){
                    Id=1,
                    Code ="CAA",
                    Name = "Caruaru",
                    SectorId = 2,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=2,
                    Code ="GAN",
                    Name = "Garanhuns",
                    SectorId = 2,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=3,
                    Code ="PMR",
                    Name = "Palmares",
                    SectorId = 2,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=4,
                    Code ="PTU",
                    Name = "Petrolina",
                    SectorId = 1,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=5,
                    Code ="SRT",
                    Name = "Serra Talhada",
                    SectorId = 1,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=6,
                    Code ="MTS",
                    Name = "Metropolitano Sul",
                    SectorId = 3,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=7,
                    Code ="MTN",
                    Name = "Metropolitano Norte",
                    SectorId = 3,
                    CreatedDate = DateTime.Now
                },
                new Npl(){
                    Id=8,
                    Code ="CPN",
                    Name = "Carpina",
                    SectorId = 3,
                    CreatedDate = DateTime.Now
                },
            });

            builder.ToTable("Npls");
        }
    }
}
