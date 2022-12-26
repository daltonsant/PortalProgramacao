
using PortalProgramacao.Application.Dtos.Dashboard;

namespace PortalProgramacao.Application.Interfaces.Services;

public interface IDashboardService
{
   object? Getdashboards(DashDto dto);

}
