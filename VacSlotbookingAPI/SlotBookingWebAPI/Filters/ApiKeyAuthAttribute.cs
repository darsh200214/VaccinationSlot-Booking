
namespace SlotBookingWebAPI.Filters
{
    #region using
    using Contracts.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        //private const string ApiKeyHeaderName = "CompanyId";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var PotentialApiKey))
            //{
            //    var errorResponse = new ErrorResponse();
            //    var errorModel = new ErrorModel
            //    {
            //        FieldName = "Company ID",
            //        Message = "company ID missing in header"
            //    };
            //    errorResponse.Errors.Add(errorModel);
            //    context.Result = new BadRequestObjectResult(errorResponse);
            //    return;
            //}

            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();

            //throw new NotImplementedException();
        }
    }
    //public class ValidatorActionFilter : ActionFilterAttribute
    //{
    //    //public override void OnActionExecuting(ActionExecutingContext context)
    //    //{
    //    //    try
    //    //    {
    //    //        //var idntity = context.HttpContext.User.Claims as ClaimsIdentity;
    //    //        var companyID = context.HttpContext.Request.Headers["CompanyID"];
    //    //        context.Result = new BadRequestObjectResult(context.ModelState);

    //    //        //string encryptedUserObjectStr = context.HttpContext.User.Claims.Where(p => p.Type == "ukeyid").FirstOrDefault().Value;

    //    //        //IEncryptDecryptAES encryptDecryptAES = new EncryptDecryptAES();
    //    //        //string userObjectStr = encryptDecryptAES.Decrypt(encryptedUserObjectStr);

    //    //        //AuthorizedUserKey authorizedUserKey = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizedUserKey>(userObjectStr);

    //    //        //if (context.Controller.ToString().ToLower().Contains("passport"))
    //    //        //{

    //    //        //}

    //    //        //if (context.ActionArguments.ContainsKey("CompanyId"))
    //    //        //{
    //    //        //    context.ActionArguments.Remove("companyId");
    //    //        //    context.ActionArguments.Add("CompanyId", Convert.ToInt32(authorizedUserKey.CompanyId));
    //    //        //}

    //    //        //if (context.ActionArguments.ContainsKey("RoleId"))
    //    //        //{

    //    //        //    context.ActionArguments.Remove("RoleId");
    //    //        //    context.ActionArguments.Add("RoleId", Convert.ToInt32(authorizedUserKey.RoleId));
    //    //        //}

    //    //        //if (context.ActionArguments.ContainsKey("userId"))
    //    //        //{

    //    //        //    context.ActionArguments.Remove("userId");
    //    //        //    context.ActionArguments.Add("UserId", Convert.ToInt32(authorizedUserKey.Id));
    //    //        //}

    //    //        //if (context.ActionArguments.ContainsKey("companyCode"))
    //    //        //{
    //    //        //    context.ActionArguments.Remove("companyCode");
    //    //        //    context.ActionArguments.Add("companyCode", authorizedUserKey.CompanyCode);
    //    //        //}
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        throw ex;
    //    //    }
    //    //}
    //}


    //public class AddRequiredHeaderParameter : IOperationFilter
    //{
    //    //public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
    //    //{
    //    //    if (operation.parameters == null)
    //    //    {
    //    //        operation.parameters = new List<Parameter>();
    //    //    }

    //    //    operation.parameters.Add(new Parameter
    //    //    {
    //    //        name = "MyHeaderField",
    //    //        @in = "header",
    //    //        type = "string",
    //    //        description = "My header field",
    //    //        required = true
    //    //    });
    //    //}

    //    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //    {
    //        if (operation.Parameters == null)
    //        {
    //            operation.Parameters = new List<OpenApiParameter>();
    //        }

    //        operation.Parameters.Add(new OpenApiParameter
    //        {
    //            Name = "companyId",
    //            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //            Required = true,
    //            Description = "company ID value"
    //        });

    //        //throw new NotImplementedException();
    //    }
    //}
}
