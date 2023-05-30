using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Departments
{
    public record GetAllDepartmentsQuery : IRequest<List<DepartmentDto>>;
}
