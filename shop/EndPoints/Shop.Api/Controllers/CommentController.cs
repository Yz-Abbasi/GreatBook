using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;

namespace Shop.Api.Controllers;
public class CommentController : ApiController
{
    private readonly ICommentFacade _commentFacade;

    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }

    [HttpGet]
    public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery]CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentByFilter(filterParams);

        return QueryResult(result);
    }
    
    [HttpGet("{commentId}")]
    public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);

        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateComment(CreateCommentCommand command)
    {
        var result = await _commentFacade.CreateComment(command);

        return CommandResult(result);
    }
    
    [HttpPut]
    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _commentFacade.EditComment(command);

        return CommandResult(result);
    }
    
    [HttpPut("changeStatus")]
    public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommand command)
    {
        var result = await _commentFacade.ChangeCommentStatus(command);

        return CommandResult(result);
    }
}