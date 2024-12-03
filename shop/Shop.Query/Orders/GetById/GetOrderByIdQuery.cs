using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto>;
}