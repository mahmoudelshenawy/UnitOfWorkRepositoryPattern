using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Employees
{
    public record DeleteOneEmployeeCommand(EmployeeDto EmployeeDto) : IRequest<bool>;
}
