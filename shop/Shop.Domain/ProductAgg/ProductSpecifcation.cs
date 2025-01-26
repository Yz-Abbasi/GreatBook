using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class ProductSpecifcation : BaseEntity
{
    public ProductSpecifcation(string key, string value)
    {
        NullOrEmptyDomainDataException.CheckString(key, nameof(key));
        NullOrEmptyDomainDataException.CheckString(value, nameof(value));

        Key = key;
        Value = value;
    }

    public long ProductId { get; internal set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
}