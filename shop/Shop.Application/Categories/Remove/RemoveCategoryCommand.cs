using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Categories.Remove
{
    public record RemoveCategoryCommand(long CategoryId) : IBaseCommand;
}