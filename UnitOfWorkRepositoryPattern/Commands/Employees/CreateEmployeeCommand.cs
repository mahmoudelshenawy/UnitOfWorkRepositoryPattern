using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Employees
{
    public record CreateEmployeeCommand(EmployeeDto Employee) : IRequest<EmployeeDto>;
}
