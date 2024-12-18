using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Inventories.GetById;
using Shop.Query.Sellers.Inventories.GetList;

namespace Shop.Presentation.Facade.Sellers.Inventories
{
    public class SellerInventoryFacade : ISellerInventoryFacade
    {
        private readonly IMediator _mediator;
    
        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
    
        public async Task<OperationResult> AddInventory(AddInventoryCommand command)
        {
            return await _mediator.Send(command);
        }
    
        public async Task<OperationResult> EditInventory(EditInventoryCommand command)
        {
            return await _mediator.Send(command);
        }
    
        public async Task<InventoryDto?> GetById(long inventoryId)
        {
            return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
        }
    
        public async Task<List<InventoryDto>> GetList(long sellerId)
        {
            return await _mediator.Send(new GetSellerInventoryListQuery(sellerId));
        }
    
        // public async Task<List<InventoryDto>> GetByProductId(long productId)
        // {
        //     return await _mediator.Send(new GetSeller(productId));
        // }
        
    }
}