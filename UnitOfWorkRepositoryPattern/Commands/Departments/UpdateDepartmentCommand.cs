using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Departments
{
    public record UpdateDepartmentCommand(DepartmentDto Department) : IRequest<bool>;
}
