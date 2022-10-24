using System;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Activities;

public class Activity
{
    public virtual string Title{ get; set; }
    public virtual string Description { get; set; }
    public virtual decimal MenHour{ get;set; }
    public virtual decimal NumberOfParticipants { get; set; }
    public virtual Npl Npl { get; set; }
    public virtual string Process { get; set; }
    public virtual string Place { get; set; }
    public virtual DateTime? ProgramedDate { get; set; }
    public virtual string Type { get; set; }
    public virtual string OsNote { get; set; }
    public virtual string CsiPreemptiveAcess { get; set; }
    public virtual ICollection<Employee> Team { get; set; }

}