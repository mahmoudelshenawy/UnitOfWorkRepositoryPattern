using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkRepositoryPattern.Api.Commands.Departments;
using UnitOfWorkRepositoryPattern.Api.Queryies.Departments;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ISender _sender;
        public DepartmentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var response = await _sender.Send(new GetAllDepartmentsQuery());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _sender.Send(new GetDepartmentByIdQuery(id));
            return department != null ? Ok(department) : NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            var response = await _sender.Send(new CreateDepartmentCommand(departmentDto));
            return CreatedAtRoute("GetDepartmentById", new { id = response.Id }, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto departmentDto)
        {
            var response = await _sender.Send(new UpdateDepartmentCommand(departmentDto));
            return response ? Ok() : BadRequest(departmentDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDepartment(DepartmentDto departmentDto)
        {
             var response = await _sender.Send(new DeleteOneDepartmentCommand(departmentDto));
            return response ? Ok() : BadRequest(departmentDto);
        }
    }
}
