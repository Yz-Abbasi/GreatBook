using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}