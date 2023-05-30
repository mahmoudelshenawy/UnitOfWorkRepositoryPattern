using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Queryies.Products;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var Products = await _unitOfWork.Products.FindListAsync(null , new []{"Category"});
            var ProductMapping = _mapper.Map<List<Product>,List<ProductDto>>(Products.ToList());
            return ProductMapping;
        }
    }
}
