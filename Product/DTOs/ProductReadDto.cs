using System.ComponentModel.DataAnnotations;

namespace Products.DTOs
{
    public class ProductReadDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
