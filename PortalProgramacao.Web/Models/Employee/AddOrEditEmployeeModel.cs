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
    public SelectList? Npls { get; set; }

    public ICollection<AddOrEditEmployeeProcessModel> EmployeeProcesses { get; set; }

    public ICollection<MonthDayCountModel> MonthDayCounts { get; set; }


    public AddOrEditEmployeeModel()
    {
        Npls = new SelectList(new List<SelectListItem>(), "Value", "Text", NplId);
        EmployeeProcesses = new List<AddOrEditEmployeeProcessModel>();
        MonthDayCounts = new List<MonthDayCountModel>();
    }
}
