using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalProgramacao.Domain.Core.Interfaces;
public interface ITransaction
{
    void Commit();
    void Rollback();
}
