using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Departments;
using UnitOfWorkRepositoryPattern.Api.Queryies.Departments;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Departments
{
    public class DeleteOneDepartmentHandler : IRequestHandler<DeleteOneDepartmentCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOneDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOneDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<DepartmentDto , Department>(request.DepartmentDto);
             _unitOfWork.Departments.DeleteAsync(department);
             var response = await _unitOfWork.Complete(cancellationToken);
             return response > 0;
        }
    }
}
