using AutoMapper;
using ManagementAPI.Models;
using ManagementAPI.Models.Dto.AreaDto;
using ManagementAPI.Models.Dto.ProcessDto;
using ManagementAPI.Models.Dto.SubprocessDto;

namespace ManagementAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Area, GetAreaDto>();
            CreateMap<AddAreaDto, Area>();
            CreateMap<Process, GetProcessDto>();
            CreateMap<AddProcessDto, Process>();
            CreateMap<Subprocess, GetSubprocessDto>();
            CreateMap<AddSubprocessDto, Subprocess>();

        }
    }
}
