using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public record EditSliderCommand(long Id, string Title, string Link, IFormFile? ImageFile) : IBaseCommand;
}