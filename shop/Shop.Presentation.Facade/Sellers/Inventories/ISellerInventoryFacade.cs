using Common.Application;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;

namespace Shop.Presentation.Facade.Sellers.Inventories
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> AddInventory(AddInventoryCommand command);
        Task<OperationResult> EditInventory(EditInventoryCommand command);

        // Task<InventoryDto?> GetById(long inventoryId);
        // Task<List<InventoryDto>> GetList(long sellerId);
        // Task<List<InventoryDto>> GetByProductId(long productId);
    }
}