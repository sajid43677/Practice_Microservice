using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
