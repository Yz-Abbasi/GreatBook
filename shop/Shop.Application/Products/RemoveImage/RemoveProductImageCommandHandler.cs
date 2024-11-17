using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        public Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}