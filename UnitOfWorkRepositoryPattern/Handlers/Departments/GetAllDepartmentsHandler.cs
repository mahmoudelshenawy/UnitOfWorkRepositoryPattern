using AutoMapper;
using MediatR;
using UnitOfWorkRepositoryPattern.Api.Queryies.Departments;
using UnitOfWorkRepositoryPattern.Core.Dtos;
using UnitOfWorkRepositoryPattern.Core.Interfaces;
using UnitOfWorkRepositoryPattern.Core.Models;

namespace UnitOfWorkRepositoryPattern.Api.Handlers.Departments
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDepartmentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {

            var departments = await _unitOfWork.Departments.FindListAsync(null , new []{"Employees"});
            var departmentMapping = _mapper.Map<List<Department>,List<DepartmentDto>>(departments.ToList());
            return departmentMapping;
        }
    }
}
