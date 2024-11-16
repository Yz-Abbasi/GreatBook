using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeStatusCommandHandler : IBaseCommandHandler<ChangeStatusCommand>
    {
        private readonly ICommentRepository _repository;

        public ChangeStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if(comment == null)
                return OperationResult.NotFound();

            comment.ChangeStatus(request.Status);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}