using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Activities;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Repositories;

public class ActivityRepository : GenericRepository<Activity, ulong>, IActivityRepository
{
    public ActivityRepository(ApplicationContext context) : base(context)
    {
    }
}