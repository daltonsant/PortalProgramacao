
using PortalProgramacao.Domain.Core.Interfaces;
using Type = PortalProgramacao.Domain.Entities.Activities.Type;

namespace PortalProgramacao.Domain.Interfaces;
public interface IActivityTypeRepository : IGenericRepository<Type,ulong>
{
   
}
