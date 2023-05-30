using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Departments;
using UnitOfWorkRepositoryPattern.Api.Queryies.Departments;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Departments
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
          var department = _mapper.Map<DepartmentDto,Department>(request.Department);
          var departmentAdded = _unitOfWork.Departments.UpdateAsync(department);
          var response = await _unitOfWork.Complete(cancellationToken);
           //var departmentDto = _mapper.Map<DepartmentDto>(departmentAdded);
           return response > 0;
        }
    }
}
