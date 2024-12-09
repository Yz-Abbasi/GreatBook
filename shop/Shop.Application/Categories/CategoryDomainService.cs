using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly ICategoryRepository _repository;
public CategoryDomainService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool DoesSlugExist(string slug)
        {
            return _repository.Exists(s => s.Slug == slug);
        }
    }
}