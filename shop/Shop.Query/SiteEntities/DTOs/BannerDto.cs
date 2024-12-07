using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Domain.SiteEntities.Enums;

namespace Shop.Query.SiteEntities.DTOs
{
    public class BannerDto : BaseDto
    {
        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }
}