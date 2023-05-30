using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkRepositoryPattern.Api.Commands.Categories;
using UnitOfWorkRepositoryPattern.Api.Queryies.Categories;
using UnitOfWorkRepositoryPattern.Core.Dtos;

namespace UnitOfWorkRepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
         private readonly ISender _sender;


        public CategoryController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _sender.Send(new GetAllCategoriesQuery());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var Category = await _sender.Send(new GetCategoryByIdQuery(id));
            return Category != null ? Ok(Category) : NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto CategoryDto)
        {
            var response = await _sender.Send(new CreateCategoryCommand(CategoryDto));
            return CreatedAtRoute("GetCategoryById", new { id = response.Id }, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(CategoryDto CategoryDto)
        {
            var response = await _sender.Send(new UpdateCategoryCommand(CategoryDto));
            return response ? Ok() : BadRequest(CategoryDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(CategoryDto CategoryDto)
        {
             var response = await _sender.Send(new DeleteOneCategoryCommand(CategoryDto));
            return response ? Ok() : BadRequest(CategoryDto);
        }
    }
}
