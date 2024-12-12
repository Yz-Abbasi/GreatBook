using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.Sellers.EditInventory;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.Sellers.Inventories;
using Shop.Query.Sellers.DTOs;

namespace Shop.Api.Controllers;

public class SellerController : ApiController
{
    private readonly ISellerFacade _sellerFacade;
    private readonly ISellerInventoryFacade _sellerInventoryFacade;

    public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
    {
        _sellerFacade = sellerFacade;
        _sellerInventoryFacade = sellerInventoryFacade;
    }


    [HttpGet]
    public async Task<ApiResult<SellerFilterResult>> GetById(SellerFilterParams filterParams)
    {
        var result = await _sellerFacade.GetSellersByFilter(filterParams);

        return QueryResult(result);
    }

    [HttpGet("{sellerId}")]
    public async Task<ApiResult<SellerDto?>> GetById(long sellerId)
    {
        var result = await _sellerFacade.GetSellerById(sellerId);

        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
    {
        var result = await _sellerFacade.CreateSeller(command);

        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditSeller(EditSellerCommand command)
    {
        var result = await _sellerFacade.EditSeller(command);

        return CommandResult(result);
    }
    
    [HttpPost("Inventory")]
    public async Task<ApiResult> AddSellerInventory(AddInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.AddInventory(command);

        return CommandResult(result);
    }
    
    [HttpPut("Inventory")]
    public async Task<ApiResult> EditSellerInventory(EditInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.EditInventory(command);

        return CommandResult(result);
    }
}