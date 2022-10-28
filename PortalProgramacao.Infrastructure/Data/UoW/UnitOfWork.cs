using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public ITransaction BeginTransaction()
        {
            return new Transaction(_context);
        }
    }
}
