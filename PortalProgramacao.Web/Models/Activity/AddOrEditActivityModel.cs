using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Activity;

public class AddOrEditActivityModel
{
    public ulong? Id { get; set; }
    
    public virtual string Key { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Chave")]
    public virtual string ApplicationID { get; set;}
    public virtual string Status { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Atividade")]
    public virtual string Title{ get; set; }
    public virtual decimal MenHour{ get;set; }
    public virtual decimal HeadCount { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "NPL")]
    public virtual ulong? NplId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Processo")]
    public virtual ulong? ProcessId { get; set; }

    public virtual string Place { get; set; }
    public virtual DateTime? ProgramedDate { get; set; }
    public virtual DateTime? DueDate { get; set; }
    public virtual DateTime? PlanedDate { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo")]
    public virtual ulong? TypeId { get; set; }
    public virtual string OsNote { get; set; }
    public virtual decimal Hours { get; set; }
    public virtual decimal ComuteTime { get; set; }
    

}
