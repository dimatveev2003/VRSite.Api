using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using VRSite.Api.Common.WebApiBase.Exceptions;
using VRSite.Api.Common.WebApiBase.Messages;

namespace VRSite.Api.Common.WebApiBase.Filters
{
    public class ServiceExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            const int badRequest = StatusCodes.Status400BadRequest;
            const int internalError = StatusCodes.Status500InternalServerError;
            JsonResult jsonResult;
            
            if (context.Exception is UnauthorizedException unauthorizedException)
            {
                jsonResult = new JsonResult(new ErrorApiResponse
                {
                    ExceptionId = new Guid(),
                    Message = "Ошибка авторизации",
                    ExceptionMessage = unauthorizedException.Message
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            } else if (context.Exception is ExceptionBase exception)
            {
                jsonResult = new JsonResult(new ErrorApiResponse
                {
                    ExceptionId = exception.StatusId,
                    Message = exception.Message,
                    ExceptionMessage = exception.Message,
                    Details = exception.Data
                })
                {
                    StatusCode = badRequest
                };
            }
            else
            {
                jsonResult = new JsonResult(new ErrorApiResponse
                {
                    ExceptionId = Guid.NewGuid(),
                    Message = "Произошла непредвиденная ошибка. Обратитесь в службу поддержки",
                    ExceptionMessage = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace,
                    Details = context.Exception.Data.Any() ? context.Exception.Data : null
                })
                {
                    StatusCode = internalError
                };
            }

            context.Result = jsonResult;
        }
    }
}