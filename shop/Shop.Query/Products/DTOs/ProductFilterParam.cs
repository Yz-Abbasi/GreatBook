using Common.Query;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParam : BaseFilterParam
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}