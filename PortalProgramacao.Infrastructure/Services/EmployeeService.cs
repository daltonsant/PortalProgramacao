using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Entities.Employees;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;

namespace PortalProgramacao.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProcessRepository _processRepository;
    private readonly INplRepository _nplRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IEmployeeRepository employeeRepository, 
    IProcessRepository processRepository, 
    INplRepository nplRepository,
    IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _processRepository = processRepository;
        _nplRepository = nplRepository;
        _unitOfWork = unitOfWork;
    }
    
    public ICollection<string> Add(EmployeeDto dto)
    {
        ICollection<string> errors = new List<string>();

        if(_employeeRepository.Entities.Count(x => x.RegisterId == dto.RegisterId) > 0)
        {
            errors.Add("Ja existe um colaborador cadastrado com a mesma matricula.");
            return errors;
        }

        var employee = GenerateEmployee(dto);
        

        using var uow = _unitOfWork.BeginTransaction();
        _employeeRepository.Save(employee);
        uow.Commit();

        return errors;
    }

    private Employee GenerateEmployee(EmployeeDto dto){
        var employee = new Employee()
        {
            Name = dto.Name,
            RegisterId = dto.RegisterId,
            CreatedDate = DateTime.Now,
        };
        var processes = _processRepository.Entities.ToList();

        employee.EnabledProcesses = new List<EmployeeProcess>();
        employee.EnabledProcesses.Add(new EmployeeProcess(){
            Employee = employee,
            Process = processes.Where(x => x.Name == "LT").FirstOrDefault(),
            Percentage = dto.LTPercentage,
            CreatedDate = DateTime.Now
        });
        employee.EnabledProcesses.Add(new EmployeeProcess(){
            Employee = employee,
            Process = processes.Where(x => x.Name == "SE").FirstOrDefault(),
            Percentage = dto.SEPercentage,
            CreatedDate = DateTime.Now
        });
        employee.EnabledProcesses.Add(new EmployeeProcess(){
            Employee = employee,
            Process = processes.Where(x => x.Name == "AUT").FirstOrDefault(),
            Percentage = dto.AUTPercentage,
            CreatedDate = DateTime.Now
        });
        employee.EnabledProcesses.Add(new EmployeeProcess(){
            Employee = employee,
            Process = processes.Where(x => x.Name == "TLE").FirstOrDefault(),
            Percentage = dto.TLEPercentage,
            CreatedDate = DateTime.Now
        });
        List<decimal> meses = new List<decimal>(){
            dto.Jan,dto.Fev,dto.Mar,dto.Abr,dto.Mai,dto.Jun,dto.Jul,dto.Ago,dto.Set,dto.Out,dto.Nov,dto.Dez
        };
        employee.MonthDayCounts = new List<MonthDayCount>();

        for(int i =0; i < 12;i++)
        {
            employee.MonthDayCounts.Add(new MonthDayCount(){
                Month = i+1,
                NumberOfDays = meses[i],
                CreatedDate = DateTime.Now
            });
        }
        if(dto.NplId.HasValue)
            employee.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Id == dto.NplId);
        else
            employee.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Code == dto.NplName);
        return employee;
    }


    public ICollection<string> Delete(ulong[] ids)
    {
        ICollection<string> errors = new List<string>();
        ulong idError = 0;
        try
        {
            using var uow =_unitOfWork.BeginTransaction();
            foreach(var id in ids)
            {
                idError = id;
                _employeeRepository.Delete(id);
            }
            uow.Commit();
        }
        catch (Exception ex)
        {
            errors.Add($"Error ao deletar colaborador de Id: {idError}");
        }

        return errors;
    }

    public ICollection<string> Edit(EmployeeDto dto)
    {
         var employee = UpdateEmployee(dto);

        if(employee != null)
        {
            using var uow = _unitOfWork.BeginTransaction();
            _employeeRepository.Update(employee);
            uow.Commit();
        }

        return null;
    }

    private Employee UpdateEmployee(EmployeeDto dto)
    {
        var employee = _employeeRepository.Entities
        .Include(x => x.EnabledProcesses)
        .ThenInclude(x => x.Process)
        .Include(x => x.MonthDayCounts)
        .FirstOrDefault(x => x.Id == dto.Id);

        if(employee != null)
        {
            var procDict = employee.EnabledProcesses
                .GroupBy(x => x.Process.Name)
                .ToDictionary(k => k.Key, v => v.First());

            if(dto.NplId.HasValue)
                employee.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Id == dto.NplId);
            else
                employee.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Code == dto.NplName);

            employee.Name = dto.Name;
            procDict["SE"].Percentage = dto.SEPercentage;
            procDict["LT"].Percentage = dto.LTPercentage;
            procDict["AUT"].Percentage = dto.AUTPercentage;
            procDict["TLE"].Percentage = dto.TLEPercentage;
            employee.UpdatedDate = DateTime.Now;

            foreach(var pr in employee.EnabledProcesses){
                pr.UpdatedDate = DateTime.Now;
            }

            var meses = employee.MonthDayCounts
                .OrderBy(x => x.Month)
                .ToList();
            meses[0].NumberOfDays = dto.Jan;
            meses[1].NumberOfDays = dto.Fev;
            meses[2].NumberOfDays = dto.Mar;
            meses[3].NumberOfDays = dto.Abr;
            meses[4].NumberOfDays = dto.Mai;
            meses[5].NumberOfDays = dto.Jun;
            meses[6].NumberOfDays = dto.Jul;
            meses[7].NumberOfDays = dto.Ago;
            meses[8].NumberOfDays = dto.Set;
            meses[9].NumberOfDays = dto.Out;
            meses[10].NumberOfDays = dto.Nov;
            meses[11].NumberOfDays = dto.Dez;

            foreach(var m in employee.MonthDayCounts)
            {
                m.UpdatedDate = DateTime.Now;
            }
            return employee;
        }

        return null;
    }


    public EmployeeDto? Get(ulong id)
    {
        return Get(new ulong[]{id})
            .FirstOrDefault();
    }

    public ICollection<EmployeeDto> Get(ulong[] ids)
    {
        var employees = _employeeRepository.Entities
        .Include(x => x.EnabledProcesses)
        .ThenInclude(x => x.Process)
        .Include(x => x.MonthDayCounts)
        .Include(x => x.Npl)
        .Where(x => ids.Contains(x.Id))
        .ToList();

        var employeeDtos = new List<EmployeeDto>();
        foreach(var employee in employees){
            var dto = new EmployeeDto()
            {
                Id = employee.Id,
                RegisterId = employee.RegisterId,
                NplId = employee.Npl.Id,
                NplName = employee.Npl.Code,
                Name = employee.Name
            };
            foreach(var process in employee.EnabledProcesses)
            {
                if(process.Process.Name == "LT")
                {
                    dto.LTPercentage = process.Percentage;
                }
                if(process.Process.Name == "SE")
                {
                    dto.SEPercentage = process.Percentage;
                }
                if(process.Process.Name == "AUT")
                {
                    dto.AUTPercentage = process.Percentage;
                }
                if(process.Process.Name == "TLE")
                {
                    dto.TLEPercentage = process.Percentage;
                }
            }
            foreach(var month in  employee.MonthDayCounts){
                if(month.Month == 1){
                    dto.Jan = month.NumberOfDays;
                }
                if(month.Month == 2){
                    dto.Fev = month.NumberOfDays;
                }
                if(month.Month == 3){
                    dto.Mar = month.NumberOfDays;
                }
                if(month.Month == 4){
                    dto.Abr = month.NumberOfDays;
                }
                if(month.Month == 5){
                    dto.Mai = month.NumberOfDays;
                }
                if(month.Month == 6){
                    dto.Jun = month.NumberOfDays;
                }
                if(month.Month == 7){
                    dto.Jul = month.NumberOfDays;
                }
                if(month.Month == 8){
                    dto.Ago = month.NumberOfDays;
                }
                if(month.Month == 9){
                    dto.Set = month.NumberOfDays;
                }
                if(month.Month == 10){
                    dto.Out = month.NumberOfDays;
                }
                if(month.Month == 11){
                    dto.Nov = month.NumberOfDays;
                }
                if(month.Month == 12){
                    dto.Dez = month.NumberOfDays;
                }
            }
            employeeDtos.Add(dto);
        }

        return employeeDtos;
    }

    public ICollection<string> Import(ICollection<EmployeeDto> employees)
    {
        var employeesToUpdate = new List<EmployeeDto>();
        var employeesToAdd = new List<EmployeeDto>();
        var entitiesToUpdate = _employeeRepository.Entities
            .Where(x => employees
                .Select(y => y.RegisterId)
                .Contains( x.RegisterId )
            );

        var registers = entitiesToUpdate.Select(y => y.RegisterId);

        employeesToUpdate = employees.Where(x => registers.Contains(x.RegisterId)).ToList();
        employeesToAdd = employees.Where(x => !registers.Contains(x.RegisterId)).ToList();

        foreach(var entity in entitiesToUpdate)
        {
            var employee = employeesToUpdate.FirstOrDefault(x => x.RegisterId == entity.RegisterId);
            if(employee != null)
                employee.Id = entity.Id;
        }
        
        ICollection<string> errors = new List<string>();

        try
        {
            using var uow = _unitOfWork.BeginTransaction();
            foreach(var dto in employeesToAdd)
            {
                var employee = GenerateEmployee(dto);
                _employeeRepository.Save(employee);
            }
            foreach(var dto in  employeesToUpdate){
                var employee = UpdateEmployee(dto);
                _employeeRepository.Update(employee);
            }
            uow.Commit();
        }
        catch (Exception ex)
        {
            errors.Add("Error ao tentar inserir os dados da importação no banco");
        }

        return errors;
    }

    public ICollection<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.Entities
        .Include(x => x.EnabledProcesses)
        .ThenInclude(x => x.Process)
        .Include(x => x.MonthDayCounts)
        .Include(x => x.Npl)
        .ToList();

        var employeeDtos = new List<EmployeeDto>();
        foreach(var employee in employees){
            var dto = new EmployeeDto()
            {
                Id = employee.Id,
                RegisterId = employee.RegisterId,
                NplId = employee.Npl.Id,
                NplName = employee.Npl.Code,
                Name = employee.Name
            };
            foreach(var process in employee.EnabledProcesses)
            {
                if(process.Process.Name == "LT")
                {
                    dto.LTPercentage = process.Percentage;
                }
                if(process.Process.Name == "SE")
                {
                    dto.SEPercentage = process.Percentage;
                }
                if(process.Process.Name == "AUT")
                {
                    dto.AUTPercentage = process.Percentage;
                }
                if(process.Process.Name == "TLE")
                {
                    dto.TLEPercentage = process.Percentage;
                }
            }
            foreach(var month in  employee.MonthDayCounts){
                if(month.Month == 1){
                    dto.Jan = month.NumberOfDays;
                }
                if(month.Month == 2){
                    dto.Fev = month.NumberOfDays;
                }
                if(month.Month == 3){
                    dto.Mar = month.NumberOfDays;
                }
                if(month.Month == 4){
                    dto.Abr = month.NumberOfDays;
                }
                if(month.Month == 5){
                    dto.Mai = month.NumberOfDays;
                }
                if(month.Month == 6){
                    dto.Jun = month.NumberOfDays;
                }
                if(month.Month == 7){
                    dto.Jul = month.NumberOfDays;
                }
                if(month.Month == 8){
                    dto.Ago = month.NumberOfDays;
                }
                if(month.Month == 9){
                    dto.Set = month.NumberOfDays;
                }
                if(month.Month == 10){
                    dto.Out = month.NumberOfDays;
                }
                if(month.Month == 11){
                    dto.Nov = month.NumberOfDays;
                }
                if(month.Month == 12){
                    dto.Dez = month.NumberOfDays;
                }
            }
            employeeDtos.Add(dto);
        }

        return employeeDtos;
    }
}