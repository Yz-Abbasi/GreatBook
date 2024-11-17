using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}