using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Employee;

public class AddOrEditEmployeeProcessModel
{

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Nome")]
    public ulong ProcessId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Porcentagem")]
    public decimal Percentage { get; set; }
    

    public AddOrEditEmployeeProcessModel()
    {
        
    }
}
