using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create
{
    internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);
            
            _repository.Add(seller);
            _repository.Save();

            return OperationResult.Success();
        }
    }
}