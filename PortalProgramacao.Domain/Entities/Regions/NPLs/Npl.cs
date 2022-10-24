using System;
using PortalProgramacao.Domain.Entities.Regions.Sectors;

namespace PortalProgramacao.Domain.Entities.Regions.NPLs;

public class Npl
{
    public virtual string Code{ get; set; }
    public virtual string Name { get; set; }

    public virtual Sector Sector { get; set;}
}