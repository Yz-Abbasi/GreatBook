using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Categories.DTOs
{
    public class SecondChildCategoryDto : BaseDto
    {
        public string Title { get;  set; }
        public string Slug { get;  set; }
        public SeoData SeoData { get;  set; }
        public long ParentId { get;  set; }
        
    }
}