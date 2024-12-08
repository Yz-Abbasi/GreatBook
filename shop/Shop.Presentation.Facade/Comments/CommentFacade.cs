using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Query.Categories.GetById;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetById;

namespace Shop.Presentation.Facade.Comments
{
    public class CommentFacade : ICommentFacade
    {
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> ChangeCommentStatus(ChangeStatusCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> CreateComment(CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditComment(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
        {
            return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
        }

        public async Task<CommentDto?> GetCommentById(long id)
        {
            return await _mediator.Send(new GetCommentByIdQuery(id));
        }
    }
}