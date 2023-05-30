using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Queryies.Employees;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Employees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {

            var Employees = await _unitOfWork.Employees.GetAllAsync(cancellationToken);
            var EmployeeMapping = _mapper.Map<List<Employee>,List<EmployeeDto>>(Employees.ToList());
            return EmployeeMapping;
        }
    }
}
