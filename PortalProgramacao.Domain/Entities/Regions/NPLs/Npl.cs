using System;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Activities;
using PortalProgramacao.Domain.Entities.Employees;
using PortalProgramacao.Domain.Entities.Regions.Sectors;

namespace PortalProgramacao.Domain.Entities.Regions.NPLs;

public class Npl : Entity<ulong>
{
    public virtual string Code { get; set; }
    public virtual string Name { get; set; }

    public virtual Sector Sector { get; set; }
    public virtual ICollection<Employee> EmployeesInNpl { get; set; }
    public virtual ICollection<Activity> Activities { get; set; }
}