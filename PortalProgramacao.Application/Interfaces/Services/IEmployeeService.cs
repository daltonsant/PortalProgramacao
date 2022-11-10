
using PortalProgramacao.Application.Dtos.Employee;

namespace PortalProgramacao.Application.Interfaces.Services;

public interface IEmployeeService
{
   public ICollection<string>? Add(EmployeeDto dto);
   public ICollection<string>? Edit(EmployeeDto dto);
   public ICollection<string>? Delete(ulong[] ids);
   public EmployeeDto? Get(ulong id);
   public ICollection<EmployeeDto> Get(ulong[] ids);

   public ICollection<string> Import(ICollection<EmployeeDto> employees);
   public ICollection<EmployeeDto> GetAll();

}
