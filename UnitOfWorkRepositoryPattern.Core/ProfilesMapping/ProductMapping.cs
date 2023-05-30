using AutoMapper;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Core.ProfilesMapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping() => CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, source => source.MapFrom(src => src.Price))
            .ForMember(dest => dest.CategoryId, source => source.MapFrom(src => src.CategoryId))
            //.ForPath(dest => dest.Category , source => source.MapFrom(src => src.Category))
            .ReverseMap();
    }
}
