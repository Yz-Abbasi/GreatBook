using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;

        public GetCommentByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Comments.OrderByDescending(d => d.CreationDate);

            if(@params.CommentStatus != null)
                result.Where(r => r.CommentStatus == @params.CommentStatus);
                
            if(@params.UserId != null)
                result.Where(r => r.UserId == @params.UserId);

            if(@params.StartDate != null)
                result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);
                
            if(@params.EndDate != null)
                result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);
            
            
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CommentFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(comment => comment.MapFilteredComment()).ToListAsync(cancellationToken),
                FilterParam = @params
            };
            
            return model;
        }
    }
}