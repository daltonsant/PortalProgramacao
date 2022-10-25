using PortalProgramacao.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Domain.Entities.Employees
{
    public class MonthDayCount : Entity<ulong>
    {
        public virtual Employee Employee { get; set; }
        public virtual int Year { get; set; }
        public virtual int Month { get; set; }
        public virtual decimal NumberOfDays { get; set; }
    }
}
