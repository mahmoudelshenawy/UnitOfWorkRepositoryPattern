using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkRepositoryPattern.Api.Commands.Employees;
using UnitOfWorkRepositoryPattern.Api.Queryies.Employees;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var response = await _sender.Send(new GetAllEmployeesQuery());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var Employee = await _sender.Send(new GetEmployeeByIdQuery(id));
            return Employee != null ? Ok(Employee) : NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto EmployeeDto)
        {
            var response = await _sender.Send(new CreateEmployeeCommand(EmployeeDto));
            return CreatedAtRoute("GetEmployeeById", new { id = response.Id }, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto EmployeeDto)
        {
            var response = await _sender.Send(new UpdateEmployeeCommand(EmployeeDto));
            return response ? Ok() : BadRequest(EmployeeDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee(EmployeeDto EmployeeDto)
        {
             var response = await _sender.Send(new DeleteOneEmployeeCommand(EmployeeDto));
            return response ? Ok() : BadRequest(EmployeeDto);
        }
    }
}
