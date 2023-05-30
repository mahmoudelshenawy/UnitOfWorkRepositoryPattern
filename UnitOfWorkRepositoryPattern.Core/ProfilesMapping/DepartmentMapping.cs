using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Core.ProfilesMapping
{
    public class DepartmentMapping : Profile
    {
        public DepartmentMapping() => CreateMap<Department, DepartmentDto>()
            .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
            .ForPath(dest => dest.Employees , source => source.MapFrom(src => src.Employees))
            .ReverseMap();
    }
}
