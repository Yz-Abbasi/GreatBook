using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Childs { get; private set; }

        private Category()
        {
            Childs = new List<Category>();
        }
        public Category(string title, string slugString, SeoData seoData, ICategoryDomainService service)
        {
            var slug = slugString?.ToSlug();
            Guard(title, slug, service);

            Title = title;
            Slug = slug;
            SeoData = seoData;
            Childs = new List<Category>();
        }


        public void Edit(string title, string slugString, SeoData seoData, ICategoryDomainService service)
        {
            var slug = slugString?.ToSlug();
            Guard(title, slug, service);
            
            Title = title;
            Slug = slug;
            SeoData = seoData;

        }

        public void AddChild(string title, string slugString, SeoData seoData, ICategoryDomainService service)
        {
            Childs.Add(new Category(title, slugString, seoData, service)
            {
                ParentId = Id
            });

        }

        public void Guard(string title, string slug, ICategoryDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug,nameof(slug));

            if(slug != Slug)
                if(service.DoesSlugExist(slug))
                    throw new SlugIsDuplicateException("Slug already exists!");
        }

    }
}