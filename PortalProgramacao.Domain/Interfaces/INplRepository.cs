using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Interfaces;
public interface INplRepository : IGenericRepository<Npl,ulong>
{
   
}
