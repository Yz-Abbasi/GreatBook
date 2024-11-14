using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        public bool DoesSlugExist(string slug);
    }
}