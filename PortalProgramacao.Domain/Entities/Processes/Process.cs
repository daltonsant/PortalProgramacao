using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Domain.Entities.Processes
{
    public class Process : Entity<ulong>
    {
        public virtual string Name { get; set; }

        public virtual ICollection<EmployeeProcess> EmployeeProcesses { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
