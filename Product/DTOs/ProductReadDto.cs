using System.ComponentModel.DataAnnotations;

namespace ProductService.DTOs
{
    public class ProductReadDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
