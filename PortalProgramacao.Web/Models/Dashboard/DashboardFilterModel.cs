
namespace PortalProgramacao.Web.Models.Dashboard;

public class DashboardFilterModel
{
    public string? process { get; set; }
    public ulong? tasktype { get; set; }
    public ulong? region { get; set; }
    public int? month {get; set; }
}