using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Products
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}