using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, 1000000)]
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
