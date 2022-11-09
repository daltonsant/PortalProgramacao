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
    public string? NplName { get; set; }
    public string? SEPercentage { get; set; }
    public string? LTPercentage { get; set; }
    public string? AUTPercentage { get; set; }
    public string? TLEPercentage { get; set; }
    public string? Jan { get; set; }
    public string? Fev { get; set; }
    public string? Mar { get; set; }
    public string? Abr { get; set; }
    public string? Mai { get; set; }
    public string? Jun { get; set; }
    public string? Jul { get; set; }
    public string? Ago { get; set; }
    public string? Set { get; set; }
    public string? Out { get; set; }
    public string? Nov { get; set; }
    public string? Dez { get; set; }

    public AddOrEditEmployeeModel()
    {
        
    }
}
