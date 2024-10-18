using System.ComponentModel.DataAnnotations;

namespace Core.Domains
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
