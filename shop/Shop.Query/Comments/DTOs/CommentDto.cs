using Common.Query;
using Shop.Domain.CommentAgg.Enums;

namespace Shop.Query.Comments.DTOs
{
    public class CommentDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public long Productid { get; set; }
        public string ProductTitle { get; set; }
        public string Text { get; private set; }
        public CommentStatus CommentStatus { get; private set; }
    }

    public class CommentFilterParams
    {
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CommentStatus CommentStatus { get; set; }
    }

    public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams>
    {

    }
}