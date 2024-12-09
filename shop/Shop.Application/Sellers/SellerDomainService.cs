using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool CheckSellerInfo(Seller seller)
        {
            var sellerExists = _repository.Exists(r => r.NationalCode == seller.NationalCode || r.UserId == seller.UserId);
            
            return !sellerExists;
        }

        public bool NationalCodeExistsInDatabase(string nationalCode)
        {
            return _repository.Exists(r => r.NationalCode == nationalCode);


        }
    }
}