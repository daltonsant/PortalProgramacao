﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    public class ProcessMap : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.UpdatedDate);
            
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();

            builder.HasMany(e => e.EmployeeProcesses).WithOne(x => x.Process);
            builder.HasMany(e => e.Activities).WithOne(x => x.Process);
            var date = new DateTime(2022, 12, 15);
            builder.HasData(new List<Process>(){
                new Process(){
                    Id = 1,
                    Name="SE",
                    CreatedDate = date
                },
                new Process(){
                    Id = 2,
                    Name="LT",
                    CreatedDate = date
                },
                new Process(){
                    Id = 3,
                    Name="AUT",
                    CreatedDate = date
                },
                new Process(){
                    Id = 4,
                    Name="TLE",
                    CreatedDate = date
                }
            });

            builder.ToTable("Processes");
        }
    }
}
