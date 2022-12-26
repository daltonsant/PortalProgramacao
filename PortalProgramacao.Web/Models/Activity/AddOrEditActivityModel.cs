using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Activity;

public class AddOrEditActivityModel
{

    public ulong? Id { get; set; }
    
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Chave")]
    public virtual string? Key { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Status")]
    public virtual string Status { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Atividade")]
    public virtual string Title{ get; set; }

    public virtual decimal? MenHour{ get;set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Head Count")]
    public virtual string HeadCount { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "NPL")]
    public virtual ulong? NplId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Processo")]
    public virtual ulong? ProcessId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "SE/LT/Outros")]
    public virtual string Place { get; set; }
    public virtual DateTime? ProgramedDate { get; set; }
    public virtual DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Data planejada")]
    public virtual DateTime? PlanedDate { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo")]
    public virtual ulong? TypeId { get; set; }
    public virtual string? OsNote { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Horas Necessárias")]
    public virtual string Hours { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Horas Deslocamento")]
    public virtual string ComuteTime { get; set; }
    public SelectList Types { get; set; }
    public SelectList Processes { get; set; }
    public SelectList StatusList { get; set; }
    
    public virtual string? Origin { get; set; }
    
    public virtual string? Csi { get; set; }
    
    public AddOrEditActivityModel()
    {
        Types = new SelectList(new List<SelectListItem>(),"Value","Text",TypeId);
        Processes = new SelectList(new List<SelectListItem>(),"Value","Text",ProcessId);
        StatusList = new SelectList(new List<SelectListItem>(),"Value","Text", Status);
    }

}
