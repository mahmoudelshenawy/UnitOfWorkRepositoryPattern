using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkRepositoryPattern.Core.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
