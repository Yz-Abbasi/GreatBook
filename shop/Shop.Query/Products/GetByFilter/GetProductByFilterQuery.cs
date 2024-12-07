using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter
{
    public class GetProductByFilterQuery : QueryFilter<productFilterResult, ProductFilterParam>
    {
        public GetProductByFilterQuery(ProductFilterParam filterParams) : base(filterParams)
        {
        }
    }
}