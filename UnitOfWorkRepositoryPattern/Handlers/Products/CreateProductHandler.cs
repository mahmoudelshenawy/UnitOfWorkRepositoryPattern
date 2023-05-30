using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Products;
using UnitOfWorkRepositoryPattern.Api.Queryies.Products;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand , ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          var Product = _mapper.Map<ProductDto,Product>(request.ProductDto);
          var ProductAdded = await _unitOfWork.Products.AddAsync(Product, cancellationToken);
           var ProductDto = _mapper.Map<ProductDto>(ProductAdded);
           return ProductDto;
        }
    }
}
