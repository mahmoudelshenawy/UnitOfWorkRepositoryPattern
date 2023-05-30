using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkRepositoryPattern.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
       // public CategoryDto? Category { get; set; }
    }
}
