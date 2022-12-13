using AutoMapper;
using PortalProgramacao.Application.Dtos.Dashboard;
using PortalProgramacao.Web.Models.Dashboard;

namespace PortalProgramacao.Web.AutoMapper.Profiles
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            
            CreateMap<DashDto, DashboardFilterModel>().ReverseMap();
        }
    }
}
