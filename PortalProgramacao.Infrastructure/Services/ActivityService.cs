using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Entities.Processes;
using PortalProgramacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Core.Interfaces;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Domain.Entities.Activities;

namespace PortalProgramacao.Infrastructure.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IProcessRepository _processRepository;
    private readonly INplRepository _nplRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IActivityTypeRepository _activityTypeRepository;

    public ActivityService(IActivityRepository activityRepository, 
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
    
    public ICollection<string> Add(ActivityDto dto)
    {
        ICollection<string> errors = new List<string>();

        if(_activityRepository.Entities.Count(x => x.Id == dto.Id) > 0)
        {
            errors.Add("Ja existe uma atividade cadastrada com o mesmo ID.");
            return errors;
        }

        var activity = GenerateActivity(dto);
        

        using var uow = _unitOfWork.BeginTransaction();
        _activityRepository.Save(activity);
        uow.Commit();

        return errors;
    }

    private Activity GenerateActivity(ActivityDto dto)
    {
        var activity = new Activity()
        {
            Title = dto.Title,
            Key = dto.Key,
            Place = dto.Place,
            OsNote = dto.OsNote ?? string.Empty,
            Status = dto.Status,
            MenHour = dto.MenHour,
            HeadCount = dto.HeadCount,
            Hours = dto.Hours,
            ComuteTime = dto.ComuteTime,
            ProgramedDate = dto.ProgramedDate,
            DueDate = dto.DueDate,
            PlanedDate = dto.PlanedDate,
            Origin = dto.Origin,
            Csi = dto.Csi,

            CreatedDate = DateTime.Now,
        };
        var processes = _processRepository.Entities.ToList();

        
        if(dto.NplId.HasValue)
            activity.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Id == dto.NplId);
        else
            activity.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Code == dto.NplName);

        if(dto.TypeId.HasValue)
            activity.Type = _activityTypeRepository.Entities.FirstOrDefault(x => x.Id == dto.TypeId);
        else
            activity.Type = _activityTypeRepository.Entities.FirstOrDefault(x => x.Name == dto.TypeName);

        if(dto.ProcessId.HasValue)
            activity.Process = processes.FirstOrDefault(x => x.Id == dto.ProcessId);
        else
            activity.Process = processes.FirstOrDefault(x => x.Name == dto.ProcessName);

        return activity;
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
                _activityRepository.Delete(id);
            }
            uow.Commit();
        }
        catch (Exception ex)
        {
            errors.Add($"Error ao deletar atividade de Id: {idError}");
        }

        return errors;
    }

    public ICollection<string> Edit(ActivityDto dto)
    {
         var activity = UpdateActivity(dto);

        if(activity != null)
        {
            using var uow = _unitOfWork.BeginTransaction();
            _activityRepository.Update(activity);
            uow.Commit();
        }

        return null;
    }

    private Activity UpdateActivity(ActivityDto dto)
    {
        var activity = _activityRepository.Entities
        .Include(x => x.Process)
        .FirstOrDefault(x => x.Id == dto.Id);

        if(activity != null)
        {
            var processes = _processRepository.Entities.ToList();

            if(dto.NplId.HasValue)
                activity.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Id == dto.NplId);
            else
                activity.Npl = _nplRepository.Entities.FirstOrDefault(x => x.Code == dto.NplName);

            if(dto.TypeId.HasValue)
                activity.Type = _activityTypeRepository.Entities.FirstOrDefault(x => x.Id == dto.TypeId);
            else
                activity.Type = _activityTypeRepository.Entities.FirstOrDefault(x => x.Name == dto.TypeName);

            if(dto.ProcessId.HasValue)
                activity.Process = processes.FirstOrDefault(x => x.Id == dto.ProcessId);
            else
                activity.Process = processes.FirstOrDefault(x => x.Name == dto.ProcessName);
            
            activity.Title = dto.Title;
            activity.Key = dto.Key;
            activity.Place = dto.Place;
            activity.OsNote = dto.OsNote ?? string.Empty;
            activity.Status = dto.Status;
            activity.MenHour = dto.MenHour;
            activity.HeadCount = dto.HeadCount;
            activity.Hours = dto.Hours;
            activity.ComuteTime = dto.ComuteTime;
            activity.ProgramedDate = dto.ProgramedDate;
            activity.DueDate = dto.DueDate;
            activity.PlanedDate = dto.PlanedDate;
            activity.Csi = dto.Csi;
            activity.Origin = dto.Origin;
            
            activity.UpdatedDate = DateTime.Now;
            return activity;
        }

        return null;
    }


    public ActivityDto? Get(ulong id)
    {
        return Get(new ulong[]{id})
            .FirstOrDefault();
    }

    public ICollection<ActivityDto> Get(ulong[] ids)
    {
        var activities = _activityRepository.Entities
        .Include(x => x.Process)
        .Include(x => x.Npl)
        .Include(x => x.Type)
        .Where(x => ids.Contains(x.Id))
        .ToList();

        var activityDtos = new List<ActivityDto>();
        foreach(var activity in activities){
            var dto = new ActivityDto()
            {
                Id = activity.Id,
                Title = activity.Title,
                Key = activity.Key,
                Place = activity.Place,
                OsNote = activity.OsNote,
                Status = activity.Status,
                MenHour = activity.MenHour,
                HeadCount = activity.HeadCount,
                Hours = activity.Hours,
                ComuteTime = activity.ComuteTime,
                ProgramedDate = activity.ProgramedDate,
                DueDate = activity.DueDate,
                PlanedDate = activity.PlanedDate,
                Origin = activity.Origin,
                Csi = activity.Csi,

                NplId = activity.Npl.Id,
                NplName = activity.Npl.Code,
                TypeId = activity.Type.Id,
                TypeName = activity.Type.Name,
                ProcessId = activity.Process.Id,
                ProcessName = activity.Process.Name,
            };
            
            activityDtos.Add(dto);
        }

        return activityDtos;
    }

    public ICollection<string> Import(ICollection<ActivityDto> activities)
    {
        var activitiesToUpdate = new List<ActivityDto>();
        var activitiesToAdd = new List<ActivityDto>();

        var idsToSearch = activities.Where(x => x.Id.HasValue).Select(x => x.Id.Value).ToList();
        var entitiesToUpdate = new List<Activity>();

        if (idsToSearch != null && idsToSearch.Any())
        {
            entitiesToUpdate = _activityRepository.Entities
            .Where(x =>idsToSearch
                .Contains(x.Id)
            ).ToList();
        }

        var registers = entitiesToUpdate.Select(y => y.Id);

        activitiesToUpdate = activities.Where(x => x.Id.HasValue && registers.Contains(x.Id.Value)).ToList();
        activitiesToAdd = activities.Where(x => !x.Id.HasValue || !registers.Contains(x.Id.Value)).ToList();
        
        ICollection<string> errors = new List<string>();

        try
        {
            using var uow = _unitOfWork.BeginTransaction();
            foreach(var dto in activitiesToAdd)
            {
                var activity = GenerateActivity(dto);
                _activityRepository.Save(activity);
            }
            foreach(var dto in  activitiesToUpdate){
                var activity = UpdateActivity(dto);
                _activityRepository.Update(activity);
            }
            uow.Commit();
        }
        catch (Exception ex)
        {
            errors.Add("Error ao tentar inserir os dados da importação no banco");
        }

        return errors;
    }

    public ICollection<ActivityDto> GetAll()
    {
        var activities = _activityRepository.Entities
        .Include(x => x.Process)
        .Include(x => x.Type)
        .Include(x => x.Npl)
        .ToList();

        var activityDtos = new List<ActivityDto>();
        foreach(var activity in activities){
            var dto = new ActivityDto()
            {
                Id = activity.Id,
                Title = activity.Title,
                Key = activity.Key,
                Place = activity.Place,
                OsNote = activity.OsNote,
                Status = activity.Status,
                MenHour = activity.MenHour,
                HeadCount = activity.HeadCount,
                Hours = activity.Hours,
                ComuteTime = activity.ComuteTime,
                ProgramedDate = activity.ProgramedDate,
                DueDate = activity.DueDate,
                PlanedDate = activity.PlanedDate,
                Origin = activity.Origin,
                Csi = activity.Csi,

                NplId = activity.Npl.Id,
                NplName = activity.Npl.Code,
                TypeId = activity.Type.Id,
                TypeName = activity.Type.Name,
                ProcessId = activity.Process.Id,
                ProcessName = activity.Process.Name,
            };
            
            
            activityDtos.Add(dto);
        }

        return activityDtos;
    }
}