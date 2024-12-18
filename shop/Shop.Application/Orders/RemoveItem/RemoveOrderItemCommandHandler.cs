using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem
{
    internal class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderItemCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if(currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.RemoveItem(request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}