using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

    }
}
