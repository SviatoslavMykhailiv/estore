using estore.domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Runtime.CompilerServices;

namespace estore.web.Filters
{
    /// <summary>
    /// Defines an exception filter
    /// </summary>
    public class ApplicationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var currentException = context.Exception;

            if (IsBadRequestException(currentException))
            {
                context.Result = new BadRequestObjectResult(new[] { currentException.Message });
                return;
            }

            if (IsNotFoundException(currentException))
            {
                context.Result = new NotFoundObjectResult(new[] { currentException.Message });
                return;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsBadRequestException(Exception exception)
        {
            return exception is BadRequestException;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsNotFoundException(Exception exception)
        {
            return exception is ItemNotFoundException;
        }
    }
}
