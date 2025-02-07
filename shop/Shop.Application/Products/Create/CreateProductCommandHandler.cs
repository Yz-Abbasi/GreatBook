using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.DomainServices;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.Create;

internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _fileService.SaveFile(request.ImageFile, Directories.productImages);
        var imageName = request.ImageFile.FileName;
        // var imageName = "hardTry.png";
        var product = new Product(request.Title, imageName, request.Description, request.Categoryid, request.SubCategoryid, request.SecondarySubCategoryid, request.Slug,
        request.SeoData, _domainService);

        _repository.Add(product);

        var specifications = new List<ProductSpecifcation>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecifcation(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);
        await _repository.Save();
        
        return OperationResult.Success();
    }
}