using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace SchedsForums.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            context.Result = exception switch
            {
                UnauthorizedAccessException => new ObjectResult("Invalid credentials")
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                },

                ArgumentNullException => new ObjectResult(new
                {
                    Message = "A required argument was null.",
                    Details = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                },

                InvalidOperationException => new ObjectResult(new
                {
                    Message = "Operation is not valid.",
                    Details = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.Conflict
                },

                _ => new ObjectResult(new
                {
                    Message = "An error occurred",
                    Details = exception.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
