using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;
using Shop.Domain.CommemtAgg.Enums;

namespace Shop.Domain.CommemtAgg
{
    public class Comment
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public CommentStatus CommentStatus { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string Text { get; private set; }


        public Comment(long userId, long productId, string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
            UserId = userId;
            ProductId = productId;
            Text = text;
            CommentStatus = CommentStatus.Pending;
        }


        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
            Text = text;
        }

        public void ChangeStatus(CommentStatus status)
        {
            CommentStatus = status;
            LastUpdate = DateTime.Now;
        }

    }
}