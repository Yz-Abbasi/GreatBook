using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddInventoryCommandHandler : IBaseCommandHandler<AddInventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public AddInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if(seller ==null)
                return OperationResult.NotFound();

            var newInventory = new SellerInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage);
            seller.AddInventory(newInventory);

            await _repository.Save();

            return OperationResult.Success();
        }
    }
}