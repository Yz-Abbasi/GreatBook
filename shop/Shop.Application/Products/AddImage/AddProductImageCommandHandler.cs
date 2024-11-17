using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Services;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly FileService _fileService;

        public AddProductImageCommandHandler(IProductRepository repository, FileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if(product == null)
                return OperationResult.NotFound();

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.productGallery);
            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();

            return  OperationResult.Success();
        }
    }
}