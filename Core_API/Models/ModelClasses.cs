using System.ComponentModel.DataAnnotations;

namespace Core_API.Models
{
    public class Category
    {
        [Key]
        public int CategoryUniqueId { get; set; }
        [Required]
        public string? CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        public int BasePrice { get; set; }
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductUniqueId { get; set;}
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public string? ProductName { get; set;}
        [Required]
        public string? Manufacturer { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryUniqueId { get; set; }
        public Category? Category { get; set; }
    }
}
