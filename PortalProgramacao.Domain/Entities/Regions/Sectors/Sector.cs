using System;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Regions.NPLs;

namespace PortalProgramacao.Domain.Entities.Regions.Sectors;

public class Sector : Entity<ulong>
{
    public virtual string Code { get; set; }
    public virtual string Name { get; set; }

    public virtual ICollection<Npl> Npls { get; set; } 
}