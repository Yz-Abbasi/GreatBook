using Shop.Api.Infrastructure.Security;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;
using Shop.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers;
public class CommentController : ApiController
{
    private readonly ICommentFacade _commentFacade;

    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }

    [PermissionChecker(Permission.Comment_Management)]
    [HttpGet]
    public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery]CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentByFilter(filterParams);

        return QueryResult(result);
    }
    
    [PermissionChecker(Permission.Comment_Management)]
    [HttpGet("{commentId}")]
    public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);

        return QueryResult(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<ApiResult> CreateComment(CreateCommentCommand command)
    {
        var result = await _commentFacade.CreateComment(command);

        return CommandResult(result);
    }
    
    [Authorize]
    [HttpPut]
    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _commentFacade.EditComment(command);

        return CommandResult(result);
    }
    
    [HttpPut("changeStatus")]
    [PermissionChecker(Permission.Comment_Management)]
    public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommand command)
    {
        var result = await _commentFacade.ChangeCommentStatus(command);

        return CommandResult(result);
    }
}