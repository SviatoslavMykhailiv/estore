using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Runtime.CompilerServices;
using estore.contracts.Exceptions;
using Microsoft.Extensions.Logging;

namespace estore.web.Filters
{
    /// <summary>
    /// Defines an exception filter
    /// </summary>
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApplicationExceptionFilterAttribute> logger;

        public ApplicationExceptionFilterAttribute(ILogger<ApplicationExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var currentException = context.Exception;

            if (IsBadRequestException(currentException))
            {
                context.Result = new BadRequestObjectResult(new[] { currentException.Message });
                context.ExceptionHandled = true;
            }

            if (IsNotFoundException(currentException))
            {
                context.Result = new NotFoundObjectResult(new[] { currentException.Message });
                context.ExceptionHandled = true;
            }

            logger.LogError(context.Exception, context.Exception.Message);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsBadRequestException(Exception exception)
        {
            return exception is RequestException;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNotFoundException(Exception exception)
        {
            return exception is ResourceException;
        }
    }
}
