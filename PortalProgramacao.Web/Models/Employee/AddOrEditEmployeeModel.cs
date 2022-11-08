using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Employee;

public class AddOrEditEmployeeModel
{
    
    public ulong? Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(32, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Matrícula U")]
    public string RegisterId { get; set; } = string.Empty;
    
    [Display(Name = "NPL")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong? NplId { get; set; }
    public string? SEPercentage { get; set; }
    public string? LTPercentage { get; set; }
    public string? AUTPercentage { get; set; }
    public string? TLEPercentage { get; set; }
    public int? Jan { get; set; }
    public int? Fev { get; set; }
    public int? Mar { get; set; }
    public int? Abr { get; set; }
    public int? Mai { get; set; }
    public int? Jun { get; set; }
    public int? Jul { get; set; }
    public int? Ago { get; set; }
    public int? Set { get; set; }
    public int? Out { get; set; }
    public int? Nov { get; set; }
    public int? Dez { get; set; }

    public AddOrEditEmployeeModel()
    {
        
    }
}
