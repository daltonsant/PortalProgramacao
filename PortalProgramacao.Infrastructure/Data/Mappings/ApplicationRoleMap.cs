using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Mappings
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Description).IsRequired().HasMaxLength(64);

            builder.HasData(
                new ApplicationRole()
                {
                    Id = "0c3959bd-151b-4447-bc7c-714dd798707d",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Description = "Administrador do sistema",
                    ConcurrencyStamp = "0c3959bd-151b-4447-bc7c-714dd798707d"
                },
                new ApplicationRole()
                {
                    Id = "d861b504-7f2c-4d37-bb12-2c1da3c206bb",
                    Name = "Programador",
                    NormalizedName = "PROGRAMADOR",
                    Description = "Usuário comum do sistema",
                    ConcurrencyStamp = "d861b504-7f2c-4d37-bb12-2c1da3c206bb"
                });

            builder.ToTable("ApplicationRoles");
        }
    }
}
