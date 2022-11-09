using AutoMapper;
using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Web.Models.Employee;

namespace PortalProgramacao.Web.AutoMapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<AddOrEditEmployeeModel, EmployeeDto>()
                .ForMember(dest => dest.AUTPercentage, opt => opt.MapFrom(src => ToDecimal(src.AUTPercentage)))
                .ForMember(dest => dest.LTPercentage, opt => opt.MapFrom(src => ToDecimal(src.LTPercentage)))
                .ForMember(dest => dest.SEPercentage, opt => opt.MapFrom(src => ToDecimal(src.SEPercentage)))
                .ForMember(dest => dest.TLEPercentage, opt => opt.MapFrom(src => ToDecimal(src.TLEPercentage)))
                .ForMember(dest => dest.Jan, opt => opt.MapFrom(src => ToDecimal(src.Jan)))
                .ForMember(dest => dest.Fev, opt => opt.MapFrom(src => ToDecimal(src.Fev)))
                .ForMember(dest => dest.Mar, opt => opt.MapFrom(src => ToDecimal(src.Mar)))
                .ForMember(dest => dest.Abr, opt => opt.MapFrom(src => ToDecimal(src.Abr)))
                .ForMember(dest => dest.Mai, opt => opt.MapFrom(src => ToDecimal(src.Mai)))
                .ForMember(dest => dest.Jun, opt => opt.MapFrom(src => ToDecimal(src.Jun)))
                .ForMember(dest => dest.Jul, opt => opt.MapFrom(src => ToDecimal(src.Jul)))
                .ForMember(dest => dest.Ago, opt => opt.MapFrom(src => ToDecimal(src.Ago)))
                .ForMember(dest => dest.Set, opt => opt.MapFrom(src => ToDecimal(src.Set)))
                .ForMember(dest => dest.Out, opt => opt.MapFrom(src => ToDecimal(src.Out)))
                .ForMember(dest => dest.Nov, opt => opt.MapFrom(src => ToDecimal(src.Nov)))
                .ForMember(dest => dest.Dez, opt => opt.MapFrom(src => ToDecimal(src.Dez)))
            .ReverseMap()
                .ForMember(dest => dest.AUTPercentage, opt => opt.MapFrom(src => src.AUTPercentage.ToString().Replace(".",",")))
                .ForMember(dest => dest.LTPercentage, opt => opt.MapFrom(src => src.LTPercentage.ToString().Replace(".",",")))
                .ForMember(dest => dest.SEPercentage, opt => opt.MapFrom(src => src.SEPercentage.ToString().Replace(".",",")))
                .ForMember(dest => dest.TLEPercentage, opt => opt.MapFrom(src => src.TLEPercentage.ToString().Replace(".",",")))
                .ForMember(dest => dest.Jan, opt => opt.MapFrom(src => src.Jan.ToString().Replace(".",",")))
                .ForMember(dest => dest.Fev, opt => opt.MapFrom(src => src.Fev.ToString().Replace(".",",")))
                .ForMember(dest => dest.Mar, opt => opt.MapFrom(src => src.Mar.ToString().Replace(".",",")))
                .ForMember(dest => dest.Abr, opt => opt.MapFrom(src => src.Abr.ToString().Replace(".",",")))
                .ForMember(dest => dest.Mai, opt => opt.MapFrom(src => src.Mai.ToString().Replace(".",",")))
                .ForMember(dest => dest.Jun, opt => opt.MapFrom(src => src.Jun.ToString().Replace(".",",")))
                .ForMember(dest => dest.Jul, opt => opt.MapFrom(src => src.Jul.ToString().Replace(".",",")))
                .ForMember(dest => dest.Ago, opt => opt.MapFrom(src => src.Ago.ToString().Replace(".",",")))
                .ForMember(dest => dest.Set, opt => opt.MapFrom(src => src.Set.ToString().Replace(".",",")))
                .ForMember(dest => dest.Out, opt => opt.MapFrom(src => src.Out.ToString().Replace(".",",")))
                .ForMember(dest => dest.Nov, opt => opt.MapFrom(src => src.Nov.ToString().Replace(".",",")))
                .ForMember(dest => dest.Dez, opt => opt.MapFrom(src => src.Dez.ToString().Replace(".",",")))
            ;

            CreateMap<EmployeeDto, ViewEmployeeModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NplName, opt => opt.MapFrom(src => src.NplName))
                .ForMember(dest => dest.RegisterId, opt => opt.MapFrom(src => src.RegisterId))
            ;



        }

        private decimal ToDecimal(string? number)
        {
            var ret = decimal.Zero;

            if(!string.IsNullOrEmpty(number))
            {
                var num = number;//.Replace(",",".");
                decimal.TryParse(num, out ret);
            }
           
            return ret;
        }
    }
}
