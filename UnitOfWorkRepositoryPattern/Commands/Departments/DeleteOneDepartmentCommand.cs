using MediatR;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Commands.Departments
{
    public record DeleteOneDepartmentCommand(DepartmentDto DepartmentDto) : IRequest<bool>;
}
