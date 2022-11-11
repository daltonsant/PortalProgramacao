using AutoMapper;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Web.Models.Activity;

namespace PortalProgramacao.Web.AutoMapper.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<AddOrEditActivityModel, ActivityDto>()
            .ReverseMap();

            CreateMap<ActivityDto, ViewActivityModel>()
                .ForMember(dest => dest.PlannedDate, opt => opt.MapFrom(src =>src.PlanedDate.HasValue ? src.PlanedDate.Value.ToShortDateString() : string.Empty))
            ;
        }
    }
}
