using System;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Employees;

public class Employee
{
    public virtual string Name{ get; set; }
    public virtual string RegisterId { get; set; }

    public virtual ICollection<Process> EnabledProcesses{ get;set; }
    public virtual ICollection<MonthDayCount> MonthDayCount { get; set; }

    public virtual Npl Npl { get; set; }

}