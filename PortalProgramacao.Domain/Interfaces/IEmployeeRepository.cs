using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Domain.Entities.Employees;

namespace PortalProgramacao.Domain.Interfaces;
public interface IEmployeeRepository : IGenericRepository<Employee,ulong>
{
   
}
