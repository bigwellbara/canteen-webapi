using Canteen.API.Contracts.Common;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.API.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        //    protected IActionResult HandleErrorResponse(List<Error> errors)
        //    {
        //        var apiResponseError = new ErrorResponse();
        //        if (errors.Any(error => error.Code == ErrorCode.NotFound))
        //        {
        //            var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);

        //            // Check if error is not null
        //            if (error != null)
        //            {
        //                // Rest compliant error response
        //                apiResponseError.StatusCode = 404;
        //                apiResponseError.StatusDescription = "Not Found";
        //                apiResponseError.Timestamp = DateTime.Now;
        //                apiResponseError.Errors.Add(error.Message);
        //                return NotFound(apiResponseError);
        //            }
        //        }

        //        apiResponseError.StatusCode = 500;
        //        apiResponseError.StatusDescription = "Internal Server Error";
        //        apiResponseError.Timestamp = DateTime.Now;
        //        apiResponseError.Errors.Add(errors.ToString());

        //        return StatusCode(500, apiResponseError);
        //    }


        //protected IActionResult HandleErrorResponse(List<Error> errors)
        //{
        //    var apiResponseError = new ErrorResponse();

        //    if (errors.Any(error => error.Code == ErrorCode.NotFound))
        //    {
        //        var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);
        //        if (error != null)
        //        {
        //            apiResponseError.StatusCode = 404;
        //            apiResponseError.StatusDescription = "Not Found";
        //            apiResponseError.Timestamp = DateTime.Now;
        //            apiResponseError.Errors.Add(error.Message);  // ✅ Modify in place
        //            return NotFound(apiResponseError);
        //        }
        //    }

        //    apiResponseError.StatusCode = 400;  // Change from 500 to 400 for validation errors
        //    apiResponseError.StatusDescription = "Validation Error";
        //    apiResponseError.Timestamp = DateTime.Now;

        //    // ✅ Modify Errors collection in place
        //    foreach (var error in errors)
        //    {
        //        apiResponseError.Errors.Add(error.Message);
        //    }

        //    return BadRequest(apiResponseError);
        //}



        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiResponseError = new ErrorResponse
            {
                Timestamp = DateTime.Now
            };

            if (errors.Any(error => error.Code == ErrorCode.ValidationError))
            {
                apiResponseError.StatusCode = (int)ErrorCode.ValidationError;
                apiResponseError.StatusDescription = "Validation Error";

               
                apiResponseError.Errors.AddRange(
                    errors.Where(e => e.Code == ErrorCode.ValidationError)
                          .SelectMany(e => e.Message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                          .Distinct()
                );

                return BadRequest(apiResponseError);
            }

            if (errors.Any(error => error.Code == ErrorCode.NotFound))
            {
                apiResponseError.StatusCode = (int)ErrorCode.NotFound;
                apiResponseError.StatusDescription = "Not Found";

                // Only add NotFound messages
                apiResponseError.Errors.AddRange(
                     errors.Where(e => e.Code == ErrorCode.NotFound)
                           .SelectMany(e => e.Message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                           .Distinct()
                 );

                return NotFound(apiResponseError);
            }

            if (errors.Any(error => error.Code == ErrorCode.UnknownError))
            {
                apiResponseError.StatusCode = (int)ErrorCode.UnknownError;
                apiResponseError.StatusDescription = "Unknown Error";

                // Only add UnknownError messages
                //apiResponseError.Errors.AddRange(
                //    errors.Where(e => e.Code == ErrorCode.UnknownError)
                //          .SelectMany(e => e.Message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                //          .Distinct()
                //);
                apiResponseError.Errors.Add("Unknown Error");

                return StatusCode(999, apiResponseError);
            }

            // Fallback for unhandled errors (filter only relevant ones)
            apiResponseError.StatusCode = (int)ErrorCode.ServerError;
            apiResponseError.StatusDescription = "Internal Server Error";
            apiResponseError.Errors.AddRange(
                    errors.Where(e => e.Code == ErrorCode.ServerError)
                          .SelectMany(e => e.Message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                          .Distinct()
                );

            return StatusCode(500, apiResponseError);
        }

    }
}
