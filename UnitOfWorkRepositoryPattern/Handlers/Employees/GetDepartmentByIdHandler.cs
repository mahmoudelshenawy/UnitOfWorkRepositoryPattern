using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Queryies.Employees;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Employees
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
           var Employee = await _unitOfWork.Employees.GetByIdAsync(request.Id);
           var EmployeeDto = _mapper.Map<Employee , EmployeeDto>(Employee);
           return EmployeeDto;
        }
    }
}