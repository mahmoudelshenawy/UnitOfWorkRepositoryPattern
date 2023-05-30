using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Queryies.Employees
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}