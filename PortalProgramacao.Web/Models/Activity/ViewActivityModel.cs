using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Activity;

public class ViewActivityModel
{
    
    public string Id { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
    public string ApplicationID { get; set; } = string.Empty;
    public string ProcessName { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;
    public string PlannedDate { get; set; } = string.Empty;
    public string DueDate { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public string NplName { get; set; } = string.Empty;

}
