using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Products
{
    public record CreateProductCommand(ProductDto ProductDto) : IRequest<ProductDto>;
}
