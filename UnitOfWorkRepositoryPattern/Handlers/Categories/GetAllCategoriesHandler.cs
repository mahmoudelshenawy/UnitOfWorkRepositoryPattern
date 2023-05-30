using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Queryies.Categories;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Categories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var Categories = await _unitOfWork.Categories.FindListAsync(null , new []{"Products"});
            var CategoryMapping = _mapper.Map<List<Category>,List<CategoryDto>>(Categories.ToList());
            return CategoryMapping;
        }
    }
}
