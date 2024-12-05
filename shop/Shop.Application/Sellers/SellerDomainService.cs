using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        public bool CheckSellerInfo(Seller seller)
        {
            throw new NotImplementedException();
        }

        public bool NationalCodeExistsInDatabase()
        {
            throw new NotImplementedException();
        }
    }
}