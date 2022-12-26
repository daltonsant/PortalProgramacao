using PortalProgramacao.Domain.Entities.Regions.Sectors;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;

namespace PortalProgramacao.Infrastructure.Data.Repositories;

public class SectorRepository : GenericRepository<Sector, ulong>, ISectorRepository
{
    public SectorRepository(ApplicationContext context) : base(context)
    {
    }
}