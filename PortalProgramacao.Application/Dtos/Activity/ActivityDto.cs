

namespace PortalProgramacao.Application.Dtos.Activity;

public class ActivityDto
{
    public ulong? Id { get; set; }
    public virtual string Key { get; set; }
    public virtual string ApplicationID { get; set;}
    public virtual string Status { get; set; }
    public virtual string Title{ get; set; }
    public virtual decimal MenHour{ get;set; }
    public virtual decimal HeadCount { get; set; }
    public virtual ulong? NplId { get; set; }
    public virtual string? NplName { get; set; }

    public virtual ulong? ProcessId { get; set; }
    public string? ProcessName { get; set; }
    public virtual string Place { get; set; }
    public virtual DateTime? ProgramedDate { get; set; }
    public virtual DateTime? DueDate { get; set; }
    public virtual DateTime? PlanedDate { get; set; }
    public virtual ulong? TypeId { get; set; }
    public virtual string? TypeName { get; set; }
    public virtual string OsNote { get; set; }
    public virtual decimal Hours { get; set; }
    public virtual decimal ComuteTime { get; set; }
}






