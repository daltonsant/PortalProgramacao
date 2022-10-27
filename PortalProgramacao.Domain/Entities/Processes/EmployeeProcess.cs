using PortalProgramacao.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Domain.Entities.Processes
{
    public class EmployeeProcess : Entity<ulong>
    {
        public virtual Process Process { get; set; }
        public virtual decimal Percentage { get; set; }
    }
}
