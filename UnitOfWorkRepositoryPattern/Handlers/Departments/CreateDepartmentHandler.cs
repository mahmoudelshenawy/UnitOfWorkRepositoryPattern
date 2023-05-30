using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Departments;
using UnitOfWorkRepositoryPattern.Api.Queryies.Departments;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Departments
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand , DepartmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
          var department = _mapper.Map<DepartmentDto,Department>(request.Department);
          var departmentAdded = await _unitOfWork.Departments.AddAsync(department, cancellationToken);
           var departmentDto = _mapper.Map<DepartmentDto>(departmentAdded);
      
           return departmentDto;
        }
    }
}
