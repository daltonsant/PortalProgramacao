using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;

using Type = PortalProgramacao.Domain.Entities.Activities.Type;

namespace PortalProgramacao.Infrastructure.Data.Repositories;

public class ActivityTypeRepository : GenericRepository<Type, ulong>, IActivityTypeRepository
{
    public ActivityTypeRepository(ApplicationContext context) : base(context)
    {
    }
}