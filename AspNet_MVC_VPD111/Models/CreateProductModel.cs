using DataAccess.Data.Entities;

namespace AspNet_MVC_VPD111.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageFile { get; set; }
        public int CategoryId { get; set; }
        public int? Discount { get; set; }
        public bool InStock { get; set; }
        public string? Description { get; set; }
    }
}
