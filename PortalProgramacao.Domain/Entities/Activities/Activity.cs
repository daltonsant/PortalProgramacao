using System;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Activities;

public class Activity : Entity<ulong>
{
    public virtual string Key { get; set; }
    public virtual string ApplicationID { get; set;}
    public virtual string Status { get; set; }
    public virtual string Title{ get; set; }
    public virtual decimal MenHour{ get;set; }
    public virtual decimal HeadCount { get; set; }
    public virtual Npl Npl { get; set; }
    public virtual Process Process { get; set; }
    public virtual string Place { get; set; }
    public virtual DateTime? ProgramedDate { get; set; }
    public virtual DateTime? DueDate { get; set; }
    public virtual DateTime? PlanedDate { get; set; }
    public virtual Type Type { get; set; }
    public virtual string OsNote { get; set; }
    public virtual decimal Hours { get; set; }
    public virtual decimal ComuteTime { get; set; }
}