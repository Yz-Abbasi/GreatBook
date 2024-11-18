using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        public bool CheckSellerInfo(Seller seller);

        public bool NationalCodeExistsInDatabase();
    }
}