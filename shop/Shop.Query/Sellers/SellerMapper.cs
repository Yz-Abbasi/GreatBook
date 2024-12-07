using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers
{
    public static class SellerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            if(seller == null)
                return null;
                
            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                SellerStatus = seller.SellerStatus,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                UserId = seller.UserId
            };
        }
    }
}