using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Products
{
    public record DeleteOneProductCommand(ProductDto ProductDto) : IRequest<bool>;
}
