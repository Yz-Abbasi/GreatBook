using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public record CreateSliderCommand(string Title, string Link, IFormFile ImageFile) : IBaseCommand;
}