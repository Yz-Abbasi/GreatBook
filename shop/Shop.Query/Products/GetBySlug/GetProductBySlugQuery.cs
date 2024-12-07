using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetBySlug
{
    public record GetProductBySlugQuery(string Slug) : IQuery<ProductDto>;
}