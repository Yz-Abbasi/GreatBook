using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeStatusCommand(long CommentId, CommentStatus Status) : IBaseCommand
    {
        
    }
}