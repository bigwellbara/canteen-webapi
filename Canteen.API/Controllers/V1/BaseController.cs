using Canteen.API.Contracts.Common;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiResponseError = new ErrorResponse();
            if (errors.Any(error => error.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);

                // Check if error is not null
                if (error != null)
                {
                    // Rest compliant error response
                    apiResponseError.StatusCode = 404;
                    apiResponseError.StatusDescription = "Not Found";
                    apiResponseError.Timestamp = DateTime.Now;
                    apiResponseError.Errors.Add(error.Message);
                    return NotFound(apiResponseError);
                }
            }

            apiResponseError.StatusCode = 500;
            apiResponseError.StatusDescription = "Internal Server Error";
            apiResponseError.Timestamp = DateTime.Now;
            apiResponseError.Errors.Add("Unknown Error Pashata");

            return StatusCode(500, apiResponseError);
        }
    }
}
