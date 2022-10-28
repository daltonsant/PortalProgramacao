using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Infrastructure.Data.Mappings;
using PortalProgramacao.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RegionMap());
            builder.ApplyConfiguration(new NplMap());

            builder.ApplyConfiguration(new ProcessMap());
            /*
            builder.ApplyConfiguration(new AssetMap());
            builder.ApplyConfiguration(new AssetTypeMap());
            builder.ApplyConfiguration(new ApplicationRoleMap());
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new AttachmentMap());
            builder.ApplyConfiguration(new ProjectMap());
            builder.ApplyConfiguration(new TaskStepMap());
            builder.ApplyConfiguration(new TaskItemMap());
            builder.ApplyConfiguration(new LinkedTasksMap());
            builder.ApplyConfiguration(new CheckListItemMap());
            builder.ApplyConfiguration(new TaskTypeMap());
            builder.ApplyConfiguration(new TaskCategoryMap());*/
        }

    }
}
