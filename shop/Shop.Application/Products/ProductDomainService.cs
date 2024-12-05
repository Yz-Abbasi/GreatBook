using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg.DomainServices;

namespace Shop.Application.Products
{
    public class ProductDomainService : IProductDomainService
    {
        public bool SlugDoesExist(string slug)
        {
            return false;
        }
    }
}