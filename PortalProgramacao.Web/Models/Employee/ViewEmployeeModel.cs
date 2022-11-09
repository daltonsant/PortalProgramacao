using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Employee;

public class ViewEmployeeModel
{
    
    public ulong Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string RegisterId { get; set; } = string.Empty;
    
    public string NplName { get; set; }

}
