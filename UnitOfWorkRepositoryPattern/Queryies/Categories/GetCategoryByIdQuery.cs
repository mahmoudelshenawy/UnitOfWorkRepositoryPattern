using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Categories
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;
}