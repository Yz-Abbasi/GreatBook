using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public record EditBannerCommand(long Id, string Link, IFormFile? ImageFile, BannerPosition BannerPosition) : IBaseCommand;
}