using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Canteen.API.Contracts.Common;

namespace Canteen.API.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var apiResponseError = new ErrorResponse();
        //        var errors = context.ModelState.AsEnumerable();
        //        // Rest compliant error response
        //        apiResponseError.StatusCode = 400;
        //        apiResponseError.StatusDescription = "Bad Requests";
        //        apiResponseError.Timestamp = DateTime.Now;
        //        foreach (var error in errors)
        //        {
        //            apiResponseError.Errors.Add(error.Value.ToString());
        //        }

        //        context.Result = new JsonResult(apiResponseError) { StatusCode = 400};

        //        //context.Result = new NotFoundObjectResult(apiResponseError);
        //        //context.Result = new BadRequestObjectResult(apiResponseError);
        //        //To Do.. make sure .Net Core does not override the custom result body

        //    }
        //}


        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiResponseError = new ErrorResponse();
                var errors = context.ModelState.AsEnumerable();
                // Rest compliant error response
                apiResponseError.StatusCode = 400;
                apiResponseError.StatusDescription = "Bad Request";
                apiResponseError.Timestamp = DateTime.Now;
                foreach (var error in errors)
                {
                    foreach (var innerError in error.Value.Errors)
                    {
                        apiResponseError.Errors.Add(innerError.ErrorMessage);
                    }

                }
                //ASPNET CORE will not override our custom result body using this OnResultExecuting method
                context.Result = new BadRequestObjectResult(apiResponseError);


            }
        }
    }
}
