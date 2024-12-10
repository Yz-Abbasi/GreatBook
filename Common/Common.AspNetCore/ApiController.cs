using System.Net;
using Common.Application;
using Microsoft.AspNetCore.Mvc;

namespace Common.AspNetCore
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result)
        {
            return new ApiResult()
            {
                IsSuccessful = result.Status == OperationResultStatus.Success,
                MetaData = new()
                {
                    Message = result.Message,
                    AppStatusCode =     result.Status.MapOperationStatus()
                }
            };
        }
        
        protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result, HttpStatusCode statusCode=HttpStatusCode.OK, string? locationUrl =null)
        {
            bool IsSuccessful = result.Status == OperationResultStatus.Success;
            if(IsSuccessful)
            {
                HttpContext.Response.StatusCode = (int)statusCode;
                if(!string.IsNullOrWhiteSpace(locationUrl))
                {
                    HttpContext.Response.Headers.Add("location", locationUrl);
                }
            }

            return new ApiResult<TData?>()
            {
                IsSuccessful = result.Status == OperationResultStatus.Success,
                Data = IsSuccessful ? result.Data : default,
                MetaData = new()
                {
                    Message = result.Message,
                    AppStatusCode =     result.Status.MapOperationStatus()
                }
            };
        }
        
        public ApiResult<TData> QueryResult<TData>(TData result)
        {
            return new ApiResult<TData>()
            {
                IsSuccessful = true,
                Data = result,
                MetaData = new()
                {
                    Message = "Operation completed successfully",
                    AppStatusCode = Enums.AppStatusCode.Success
                }
            };
        }
    }
}