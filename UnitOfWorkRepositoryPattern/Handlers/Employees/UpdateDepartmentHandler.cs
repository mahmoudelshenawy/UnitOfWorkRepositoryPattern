using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Commands.Employees;
using UnitOfWorkRepositoryPattern.Api.Queryies.Employees;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Employees
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand , bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
          var Employee = _mapper.Map<EmployeeDto,Employee>(request.Employee);
          var EmployeeAdded = _unitOfWork.Employees.UpdateAsync(Employee);
          var response = await _unitOfWork.Complete(cancellationToken);
           //var EmployeeDto = _mapper.Map<EmployeeDto>(EmployeeAdded);
           return response > 0;
        }
    }
}
