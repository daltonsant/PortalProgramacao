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
                .ForMember(dest => dest.Key, opt  => opt.MapFrom(src => src.Key ?? string.Empty))
                .ForMember(dest=> dest.HeadCount, opt => opt.MapFrom(src => decimal.Parse(src.HeadCount)))
                .ForMember(dest => dest.ComuteTime, opt => opt.MapFrom(src => decimal.Parse(src.ComuteTime)))
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => decimal.Parse(src.Hours)))
            .ReverseMap()
                .ForMember(dest => dest.ComuteTime, opt => opt.MapFrom(src => src.ComuteTime.ToString()))
                .ForMember(dest => dest.ComuteTime, opt => opt.MapFrom(src => src.ComuteTime.ToString()))
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => src.Hours.ToString()));

            CreateMap<ActivityDto, ViewActivityModel>()
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.PlannedDate, opt => opt.MapFrom(src =>src.PlanedDate.HasValue ? src.PlanedDate.Value.ToShortDateString() : string.Empty))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                ;
        }
    }
}
