using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById
{
    public record GetSellerByIdQuery(long Id) : IQuery<SellerDto>;
}