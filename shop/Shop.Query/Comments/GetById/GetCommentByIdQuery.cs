using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    internal record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto?>;
}