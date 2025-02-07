using AngleSharp.Io;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.DomainServices;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.Edit;

internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if(product == null)
            return OperationResult.NotFound();

        product.EditProduct(request.Title, request.Description, request.Categoryid, request.SubCategoryid, request.SecondarySubCategoryid, request.Slug, request.SeoData,
        _domainService);

        var oldImage = product.ImageName;

        if(request.ImageFile != null)
        {
            await _fileService.SaveFile(request.ImageFile, Directories.productImages);
            var imageName = request.ImageFile.FileName;
            product.SetProductImage(imageName);
        }

        var specifications = new List<ProductSpecifcation>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecifcation(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);
        await _repository.Save();
        RemoveOldImage(request.ImageFile, oldImage);

        return OperationResult.Success();
    }

    private void RemoveOldImage(IFormFile imageFile, string oldImageName)
    {
        if(imageFile != null)
        {
            _fileService.DeleteFile(Directories.productImages, oldImageName);
        }
    }
}