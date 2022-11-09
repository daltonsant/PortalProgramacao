using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Entities.Processes;

namespace PortalProgramacao.Domain.Interfaces;
public interface IProcessRepository : IGenericRepository<Process,ulong>
{
   
}
