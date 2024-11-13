using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.DomainServices;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long Categoryid { get; private set; }
        public long SubCategoryid { get; private set; }
        public long SecondarySubCategoryid { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecifcation> Specifications { get; private set; }


        private Product()
        {

        }
        public Product(string title, string imageName, string description, long categoryid, long subCategoryid, long secondarySubCategoryid, string slug, SeoData seoData,
        IProductDomainService domainService)
        {
            Guard(title, slug, imageName, description, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            Categoryid = categoryid;
            SubCategoryid = subCategoryid;
            SecondarySubCategoryid = secondarySubCategoryid;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }


        public void EditProduct(string title, string imageName, string description, long categoryid, long subCategoryid, long secondarySubCategoryid, string slug, SeoData seoData,
        IProductDomainService domainService)
        {
            Guard(title, slug, imageName, description, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            Categoryid = categoryid;
            SubCategoryid = subCategoryid;
            SecondarySubCategoryid = secondarySubCategoryid;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void AddImage(ProductImage image)
        {
            Images.Add(image);
        }

        public void RemoveImage(long imageId)
        {
            var image = Images.FirstOrDefault(f => f.Id == Id);
            if(image == null)
                return ;
            
            Images.Remove(image);
        }

        public void SetSpecification(List<ProductSpecifcation> specifcations)
        {
            specifcations.ForEach(s => s.ProductId = Id);
            Specifications = specifcations;
        }

        public void Guard(string title,string slug, string imageName, string description, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if(slug != Slug)
            {
                if(domainService.SlugDoesExist(slug.ToSlug()))
                    throw new SlugIsDuplicateException();
            }
        }
    }
}