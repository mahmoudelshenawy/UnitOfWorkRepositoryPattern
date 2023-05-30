using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Categories;
using UnitOfWorkRepositoryPattern.Api.Queryies.Categories;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand , CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
          var Category = _mapper.Map<CategoryDto,Category>(request.Category);
          var CategoryAdded = await _unitOfWork.Categories.AddAsync(Category, cancellationToken);
           var CategoryDto = _mapper.Map<CategoryDto>(CategoryAdded);
           return CategoryDto;
        }
    }
}
