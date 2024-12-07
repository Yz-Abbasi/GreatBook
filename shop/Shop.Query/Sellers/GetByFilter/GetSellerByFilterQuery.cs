using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
}