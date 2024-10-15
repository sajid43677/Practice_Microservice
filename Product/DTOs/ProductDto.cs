using System.ComponentModel.DataAnnotations;

namespace Product.DTOs
{
    public class ProductDto
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
