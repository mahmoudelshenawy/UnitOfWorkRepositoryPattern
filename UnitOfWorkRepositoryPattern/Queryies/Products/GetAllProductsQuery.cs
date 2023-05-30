using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Products
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>;
}
