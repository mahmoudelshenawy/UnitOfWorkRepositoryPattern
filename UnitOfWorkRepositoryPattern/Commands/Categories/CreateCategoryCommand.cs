using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Categories
{
    public record CreateCategoryCommand(CategoryDto Category) : IRequest<CategoryDto>;
}
