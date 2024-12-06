using Common.Query;

namespace Shop.Query.Products.DTOs
{
    public class ProductSpecificationDto
    {
        public long ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}