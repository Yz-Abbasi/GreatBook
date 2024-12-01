using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
    {
        private readonly ShopContext _context;

        public GetCommentByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        async Task<CommentDto> IRequestHandler<GetCommentByIdQuery, CommentDto>.Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId);
            

            return comment.Map();
        }
    }
}