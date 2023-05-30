using AutoMapper;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Core.ProfilesMapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping() => CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
            .ForPath(dest => dest.Products , source => source.MapFrom(src => src.Products))
            .ReverseMap();
    }
}
