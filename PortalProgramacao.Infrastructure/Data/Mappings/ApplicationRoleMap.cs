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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Description = "Administrador do sistema"
                },
                new ApplicationRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Programador",
                    NormalizedName = "PROGRAMADOR",
                    Description = "Usuário comum do sistema"
                });

            builder.ToTable("ApplicationRoles");
        }
    }
}
