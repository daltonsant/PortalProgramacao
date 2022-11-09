using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Core.Models;
using PortalProgramacao.Domain.Entities.Activities;
using PortalProgramacao.Domain.Entities.Employees;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.Repositories;

public class ProcessRepository : GenericRepository<Process, ulong>, IProcessRepository
{
    public ProcessRepository(ApplicationContext context) : base(context)
    {
    }
}