using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Canteen.API.Contracts.Common;

namespace Canteen.API.Filters
{
    public class ValidateGuidAttribute : ActionFilterAttribute
    {
        private readonly string _key;
        public ValidateGuidAttribute(string key)
        {
            _key = key;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue(_key, out var value))
            {
                return;
            }

            if (Guid.TryParse(value?.ToString(), out var guid))
            {
                return;
            }

            var apiResponseError = new ErrorResponse()
            {
                StatusCode = 400,
                StatusDescription = "Bad Request",
                Timestamp = DateTime.Now

            };

            apiResponseError.Errors.Add($"The identifier for {_key} is not a valid Guid format.");
            context.Result = new ObjectResult(apiResponseError);


        }
    }
}
