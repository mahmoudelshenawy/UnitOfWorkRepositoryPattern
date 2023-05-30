using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Products;
using UnitOfWorkRepositoryPattern.Api.Queryies.Products;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Products
{
    public class DeleteOneProductHandler : IRequestHandler<DeleteOneProductCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOneProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOneProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _mapper.Map<ProductDto , Product>(request.ProductDto);
             _unitOfWork.Products.DeleteAsync(Product);
             var response = await _unitOfWork.Complete(cancellationToken);
             return response > 0;
        }
    }
}
