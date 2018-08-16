using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Runtime.CompilerServices;
using estore.contracts.Exceptions;

namespace estore.web.Filters
{
    /// <summary>
    /// Defines an exception filter
    /// </summary>
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
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
        private static bool IsBadRequestException(Exception exception)
        {
            return exception is BadRequestException;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNotFoundException(Exception exception)
        {
            return exception is ItemNotFoundException;
        }
    }
}
