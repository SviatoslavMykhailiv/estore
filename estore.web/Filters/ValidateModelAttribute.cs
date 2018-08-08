using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace estore.web.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestObjectResult(context
                    .ModelState
                    .Values
                    .SelectMany(value => value.Errors)
                    .Select(c => c.ErrorMessage));

                return;
            }
        }
    }
}
