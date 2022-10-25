using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public string Description { get; set; } = string.Empty;
    }
}
