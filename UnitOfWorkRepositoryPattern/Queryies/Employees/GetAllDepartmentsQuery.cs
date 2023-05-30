using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Employees
{
    public record GetAllEmployeesQuery : IRequest<List<EmployeeDto>>;
}
