using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Url]
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        [Range (0, 100)]
        public int? Discount { get; set; }
        public bool InStock { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string? Description { get; set; }

        // ---------- navigation properties
        public Category? Category { get; set; }
    }
}
