using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Departments
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentDto>;
}