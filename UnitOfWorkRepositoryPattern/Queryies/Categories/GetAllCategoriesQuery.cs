using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Categories
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
}
