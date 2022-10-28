using System;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Employees;

public class Employee : Entity<ulong>
{
    public virtual string Name{ get; set; }
    public virtual string RegisterId { get; set; }

    public virtual ICollection<EmployeeProcess> EnabledProcesses { get;set; }
    public virtual ICollection<MonthDayCount> MonthDayCounts { get; set; }

    public virtual Npl Npl { get; set; }

}