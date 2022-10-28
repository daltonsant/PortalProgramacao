using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Infrastructure.Data.UoW
{
    public class Transaction : DbLoggerCategory.Database.Transaction, ITransaction
    {
        private readonly IDbContextTransaction _transaction;
        private readonly ApplicationContext _context;

        public Transaction(ApplicationContext context)
        {
            _transaction = context.Database.BeginTransaction();
            _context = context;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
