using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Services;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly FileService _fileService;

        public RemoveProductImageCommandHandler(IProductRepository repository, FileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if(product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);

            await _repository.Save();
            _fileService.DeleteFile(Directories.productGallery, imageName);
            return OperationResult.Success();
        }
    }
}