using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Departments
{
    public record CreateDepartmentCommand(DepartmentDto Department) : IRequest<DepartmentDto>;
}
