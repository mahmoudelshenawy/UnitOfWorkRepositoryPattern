using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Categories
{
    public record UpdateCategoryCommand(CategoryDto Category) : IRequest<bool>;
}
