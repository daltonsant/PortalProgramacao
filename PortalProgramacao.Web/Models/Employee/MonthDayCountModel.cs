using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Employee;

public class MonthDayCountModel
{

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Mês")]
    public int Month { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Dias Disponíveis")]
    public decimal Days { get; set; }
    

    public MonthDayCountModel()
    {
        
    }
}
