using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Categories;
using UnitOfWorkRepositoryPattern.Api.Queryies.Categories;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Categories
{
    public class DeleteOneCategoryHandler : IRequestHandler<DeleteOneCategoryCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOneCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOneCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = _mapper.Map<CategoryDto , Category>(request.CategoryDto);
             _unitOfWork.Categories.DeleteAsync(Category);
             var response = await _unitOfWork.Complete(cancellationToken);
             return response > 0;
        }
    }
}
