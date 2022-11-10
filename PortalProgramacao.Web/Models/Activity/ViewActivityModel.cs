using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalProgramacao.Web.Models.Activity;

public class ViewActivityModel
{
    
    public string Id { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty; 
    public string ApplicationID { get; set; } = string.Empty;
    public string Process { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string PlannedDate { get; set; } = string.Empty;
    public string DueDate { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public string NplName { get; set; } = string.Empty;

}
