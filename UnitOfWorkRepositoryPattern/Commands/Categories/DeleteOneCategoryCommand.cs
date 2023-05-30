using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Categories
{
    public record DeleteOneCategoryCommand(CategoryDto CategoryDto) : IRequest<bool>;
}
