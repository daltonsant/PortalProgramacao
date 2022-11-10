

using PortalProgramacao.Application.Dtos.Activity;

namespace PortalProgramacao.Application.Interfaces.Services;
public interface IActivityService
{
   
    public ICollection<string>? Add(ActivityDto dto);
    public ICollection<string>? Edit(ActivityDto dto);
    public ICollection<string>? Delete(ulong[] ids);
    public ActivityDto? Get(ulong id);
    public ICollection<ActivityDto> Get(ulong[] ids);

    public ICollection<string> Import(ICollection<ActivityDto> activities);
    public ICollection<ActivityDto> GetAll();


}
