using System;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Activities;

public class Employee
{
    public virtual string Name{ get; set; }
    public virtual string Role { get; set; }

    public virtual decimal MenHour{ get;set; }
    public virtual decimal NumberOfParticipants { get; set; }

    public virtual Npl Npl { get; set; }

}