

namespace Shop.Domain.ProductAgg.DomainServices
{
    public interface IProductDomainService
    {
        bool SlugDoesExist(string slug);
    }
}