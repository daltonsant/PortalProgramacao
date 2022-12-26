using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Domain.Entities.Activities;
using PortalProgramacao.Application.Dtos.Dashboard;
using SQLitePCL;

namespace PortalProgramacao.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IProcessRepository _processRepository;
    private readonly INplRepository _nplRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISectorRepository _sectorRepository;

    public DashboardService(IActivityRepository activityRepository, 
    IProcessRepository processRepository, 
    INplRepository nplRepository,
    ISectorRepository sectorRepository,
    IEmployeeRepository employeeRepository)
    {
        _activityRepository = activityRepository;
        _processRepository = processRepository;
        _nplRepository = nplRepository;
        _sectorRepository = sectorRepository;
        _employeeRepository = employeeRepository;
    }

    private object? GetProcPerRegion(DashDto dto)
    {
        var activityQuery = _activityRepository.Entities
            .Include(x => x.Npl).ThenInclude(x => x.Sector).Include(x => x.Process).AsQueryable();

        var m = 0;
        if (dto.month.HasValue)
        {
            m = dto.month.Value;
            activityQuery = activityQuery.Where(x => x.ProgramedDate.HasValue ? x.ProgramedDate.Value.Month == m :
                (x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == m : false));
        }
        
        var activities = activityQuery.ToList();
        
        var employeeQuery = _employeeRepository.Entities.Include(x => x.Npl).ThenInclude(x => x.Sector)
            .Include(x => x.EnabledProcesses).ThenInclude(x => x.Process)
            .Include(x => x.MonthDayCounts).AsQueryable();

        if (dto.month.HasValue)
        {
            employeeQuery = employeeQuery.Where(x => x.MonthDayCounts.Any(y => y.Month == dto.month.Value && y.NumberOfDays > 0));
        }

        var regs = _sectorRepository.Entities.Include(x => x.Npls).ToList().OrderBy(x => x.Id).ToList();
        var procs = _processRepository.Entities.ToList(); 
       
        
        var result = new List<object[]>
        {
            new object[] //header
            {
                "Region", "SE", "LT", "AUT", "TLE"
            }
        };

        foreach (var reg in regs)
        {
            var objs = new object[result[0].Length];
            objs[0] = reg.Code;
            int i = 1;
            var regActivities = activities.Where(x => x.Npl.Sector.Id == reg.Id);
            var regEmployees = employeeQuery.Where(x => reg.Npls.Contains(x.Npl));
            
            foreach (var proc in procs)
            {
                var per = regActivities.Where(x => x.Process.Id == proc.Id).Sum(act => (act.HeadCount * act.Hours) + act.ComuteTime);
                var emp = decimal.Zero;//emp.MonthDayCounts.FirstOrDefault(emp=> emp.Month == m)?.NumberOfDays ?? decimal.Zero;
                if (!dto.month.HasValue)
                {
                    emp = regEmployees.ToList().Sum(x =>
                        x.MonthDayCounts.Sum(y => y.NumberOfDays) * 7.5m * 
                        (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                            .Sum(d => d.Percentage)/100.0m));
                }
                else
                {
                    emp = regEmployees.ToList().Sum(x =>
                        x.MonthDayCounts.Where(m => m.Month == dto.month)
                            .Sum(y => y.NumberOfDays) * 7.5m * 
                        (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                            .Sum(d => d.Percentage)/100.0m));
                }
                
                objs[i++] = emp != decimal.Zero ? decimal.Round(per * 100.0m / emp, 2) : decimal.Zero;
            }
            
            result.Add(objs);
        }
        
        //Add NSPS (all)
        var nspsObjs = new object[result[0].Length];
        nspsObjs[0] = "NST";
        int j = 1;
        var nspsActivities = activities;
        var nspsEmployees = employeeQuery;
            
        foreach (var proc in procs)
        {
            var per = nspsActivities.Where(x => x.Process.Id == proc.Id).Sum(act => (act.HeadCount * act.Hours) + act.ComuteTime);
            var emp = decimal.Zero;//emp.MonthDayCounts.FirstOrDefault(emp=> emp.Month == m)?.NumberOfDays ?? decimal.Zero;
            if (!dto.month.HasValue)
            {
                emp = nspsEmployees.ToList().Sum(x =>
                    x.MonthDayCounts.Sum(y => y.NumberOfDays) * 7.5m * 
                    (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                        .Sum(d => d.Percentage)/100.0m));
            }
            else
            {
                emp = nspsEmployees.ToList().Sum(x =>
                    x.MonthDayCounts.Where(m => m.Month == dto.month)
                        .Sum(y => y.NumberOfDays) * 7.5m * 
                    (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                        .Sum(d => d.Percentage)/100.0m));
            }

            nspsObjs[j++] = emp != decimal.Zero ? decimal.Round(per * 100.0m / emp, 2) : decimal.Zero;
        }
            
        result.Add(nspsObjs);
        

        return result.ToArray();
    }
    
    private object? GetProcPerNpl(DashDto dto)
    {
        var activityQuery = _activityRepository.Entities
            .Include(x => x.Npl).ThenInclude(x => x.Sector).Include(x => x.Process).AsQueryable();

        var m = 0;
        if (dto.month.HasValue)
        {
            m = dto.month.Value;
            activityQuery = activityQuery.Where(x => x.ProgramedDate.HasValue ? x.ProgramedDate.Value.Month == m :
                (x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == m : false));
        }
        
        var activities = activityQuery.ToList();
        
        var employeeQuery = _employeeRepository.Entities.Include(x => x.Npl).ThenInclude(x => x.Sector)
            .Include(x => x.EnabledProcesses).ThenInclude(x => x.Process)
            .Include(x => x.MonthDayCounts).AsQueryable();

        if (dto.month.HasValue)
        {
            employeeQuery = employeeQuery.Where(x => x.MonthDayCounts.Any(y => y.Month == dto.month.Value && y.NumberOfDays > 0));
        }

        var npls = _nplRepository.Entities.OrderBy(x => x.Code).ToList();
        var procs = _processRepository.Entities.ToList(); 
       
        
        var result = new List<object[]>
        {
            new object[] //header
            {
                "NPL", "SE", "LT", "AUT", "TLE"
            }
        };

        foreach (var npl in npls)
        {
            var objs = new object[result[0].Length];
            objs[0] = npl.Code;
            int i = 1;
            var nplActivities = activities.Where(x => x.Npl.Id == npl.Id);
            var nplEmployees = employeeQuery.Where(x => x.Npl.Id == npl.Id);
            
            foreach (var proc in procs)
            {
                var per = nplActivities.Where(x => x.Process.Id == proc.Id).Sum(act => (act.HeadCount * act.Hours) + act.ComuteTime);
                var emp = decimal.Zero;//emp.MonthDayCounts.FirstOrDefault(emp=> emp.Month == m)?.NumberOfDays ?? decimal.Zero;
                if (!dto.month.HasValue)
                {
                    emp = nplEmployees.ToList().Sum(x =>
                        x.MonthDayCounts.Sum(y => y.NumberOfDays) * 7.5m * 
                        (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                            .Sum(d => d.Percentage)/100.0m));
                }
                else
                {
                    emp = nplEmployees.ToList().Sum(x =>
                        x.MonthDayCounts.Where(m => m.Month == dto.month)
                            .Sum(y => y.NumberOfDays) * 7.5m * 
                        (x.EnabledProcesses.Where(z => z.Process.Id == proc.Id)
                            .Sum(d => d.Percentage)/100.0m));
                }
                Console.WriteLine(emp);
                Console.WriteLine(per);

                objs[i++] = emp != decimal.Zero ? decimal.Round(per * 100.0m / emp, 2) : decimal.Zero;
            }
            
            result.Add(objs);
        }

        return result.ToArray();
    }
  
    public object? Getdashboards(DashDto dto)
    {
        return new
        {
            charts = new object[]
            {
                GetProcPerRegion(dto),
                GetProcPerNpl(dto),
            }
        };
    }
}