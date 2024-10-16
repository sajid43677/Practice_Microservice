using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
