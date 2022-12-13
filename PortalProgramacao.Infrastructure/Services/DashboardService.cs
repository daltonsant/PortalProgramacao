using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Domain.Entities.Activities;
using PortalProgramacao.Application.Dtos.Dashboard;

namespace PortalProgramacao.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IProcessRepository _processRepository;
    private readonly INplRepository _nplRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IActivityTypeRepository _activityTypeRepository;

    public DashboardService(IActivityRepository activityRepository, 
    IProcessRepository processRepository, 
    INplRepository nplRepository,
    IActivityTypeRepository activityTypeRepository,
    IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _processRepository = processRepository;
        _nplRepository = nplRepository;
        _unitOfWork = unitOfWork;
        _activityTypeRepository = activityTypeRepository;
    }
    
  
    public object? Getdashboards(DashDto dto)
    {
        


        
        return null;
    }
}