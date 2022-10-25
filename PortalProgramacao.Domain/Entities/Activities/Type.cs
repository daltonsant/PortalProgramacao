using PortalProgramacao.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Domain.Entities.Activities
{
    public class Type : Entity<ulong>
    {
        public virtual string Name { get; set; }
    }
}
