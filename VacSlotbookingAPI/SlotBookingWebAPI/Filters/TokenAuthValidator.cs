
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlotBookingWebAPI.Filters
{
    public class TokenAuthValidator : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.Filters.OfType<SkipMyGlobalActionFilterAttribute>().Any())
            {
                try
                {
                    bool success = Int32.TryParse(context.HttpContext.User.Claims.Where(p => p.Type == "Id").FirstOrDefault().Value, out int _UserId);
                    if (!success)
                    {
                        var errorResponse = new ErrorResponse();
                        var errorModel = new ErrorModel
                        {
                            FieldName = "UserId",
                            Message = "UserId missing from AuthToken"
                        };
                        errorResponse.Errors.Add(errorModel);
                        context.Result = new BadRequestObjectResult(errorResponse);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    var errorResponse = new ErrorResponse();
                    var errorModel = new ErrorModel
                    {
                        FieldName = "UserId",
                        Message = "Error in fetching UserId from AuthToken"
                    };
                    errorResponse.Errors.Add(errorModel);
                    context.Result = new BadRequestObjectResult(errorResponse);
                    return;
                }
            }
            await next();
            //throw new NotImplementedException();
        }
    }
    public class SkipMyGlobalActionFilterAttribute : Attribute, IFilterMetadata
    {
    }
}
