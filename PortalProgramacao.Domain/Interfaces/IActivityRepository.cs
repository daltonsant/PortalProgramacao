using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Activities;

namespace PortalProgramacao.Domain.Interfaces;
public interface IActivityRepository : IGenericRepository<Activity,ulong>
{
   
}
