using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode) : IBaseCommand;
}