using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg;

namespace Shop.Application.Categories.Remove
{
    public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteCategory(request.CategoryId);
            if(result)
                return OperationResult.Success();
            
            return OperationResult.Error("Can't delete this category!");
        }
    }
}