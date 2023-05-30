using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Employees
{
    public record UpdateEmployeeCommand(EmployeeDto Employee) : IRequest<bool>;
}
