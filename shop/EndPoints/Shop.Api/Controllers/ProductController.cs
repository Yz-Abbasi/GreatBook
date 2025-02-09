using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs;
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Shop.Api.ViewModels.Products;

namespace Shop.Api.Controllers;

// [PermissionChecker(Permission.CRUD_Product)]
public class ProductController : ApiController
{
    private readonly IProductFacade _productFacade;

    public ProductController(IProductFacade productFacade)
    {
        _productFacade = productFacade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<productFilterResult>> GetProductsByFilter([FromQuery]ProductFilterParam filterParam)
    {
        return QueryResult(await _productFacade.GetProductsByFilter(filterParam));
    }

    [AllowAnonymous]
    [HttpGet("Shop")]
    public async Task<ApiResult<ProductShopResult>> GetProductsForShopFilter([FromQuery]ProductShopFilterparam filterParam)
    {
        return QueryResult(await _productFacade.GetProductsForShop(filterParam));
    }

    [AllowAnonymous]
    [HttpGet("{productId}")]
    public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
    {
        var product = await _productFacade.GetProductById(productId);

        return QueryResult(product);
    }
    
    [AllowAnonymous]
    [HttpGet("BySlug/{slug}")]
    public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
    {
        var product = await _productFacade.GetProductBySlug(slug);
        
        return QueryResult(product);
    }

    [HttpPost]
    public async Task<ApiResult> CreateProduct([FromForm]CreateProductViewModel command)
    {
        var result = await _productFacade.CreateProduct(new CreateProductCommand()
        {
            SeoData = command.SeoData.Map(),
            Description = command.Description,
            ImageFile = command.ImageFile,
            Categoryid = command.CategoryId,
            SubCategoryid = command.SubCategoryId,
            SecondarySubCategoryid = command.SecondarySubCategoryId,
            Slug = command.Slug,
            Specifications = command.GetSpecification(),
            Title = command.Title,
        });

        return CommandResult(result);
    }
    
    [HttpPost("images")]
    public async Task<ApiResult> AddImage([FromForm]AddProductImageViewModel command)
    {
        var result = await _productFacade.AddImage(new AddProductImageCommand(
            command.ImageFile,
            command.ProductId,
            command.Sequence
        ));

        return CommandResult(result);
    }
    
    [HttpDelete("images")]
    public async Task<ApiResult> RemoveImage(RemoveProductImageCommand command)
    {
        var result = await _productFacade.RemoveImage(command);

        return CommandResult(result);
    }
    
    [HttpPut]
    public async Task<ApiResult> EditProduct([FromForm]EditProductViewModel command)
    {
        var result = await _productFacade.EditProduct(new EditProductCommand(command.ProductId,
            command.Title,
            command.ImageFile,
            command.Description,
            command.CategoryId,
            command.SubCategoryId,
            command.SecondarySubCategoryId,
            command.Slug,
            command.SeoData.Map(),
            command.GetSpecification())
        {
        });

        return CommandResult(result);
    }
}