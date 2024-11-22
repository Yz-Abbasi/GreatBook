using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await Context.Categories
                .Include(c => c.Childs)
                .ThenInclude(c => c.Childs).FirstOrDefaultAsync(f => f.Id == categoryId);
            if(category == null)
                return false;

            var doesProductExist = await Context.Products
                .AnyAsync(f => f.Categoryid == categoryId ||
                                f.SubCategoryid == categoryId ||
                                f.SecondarySubCategoryid == categoryId);
            if(doesProductExist == true)
                return false;

            if(category.Childs.Any(c => c.Childs.Any()))
            {
                Context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
            }
            Context.RemoveRange(category.Childs);
            Context.RemoveRange(category);

            return true;
        }
    }
}