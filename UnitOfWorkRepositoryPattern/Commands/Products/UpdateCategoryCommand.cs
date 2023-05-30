using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Products
{
    public record UpdateProductCommand(ProductDto ProductDto) : IRequest<bool>;
}
