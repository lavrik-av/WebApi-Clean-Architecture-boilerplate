using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Boilerplate.WebApi.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception);
            }
        }

        public async Task HandleException(HttpContext context, Exception exception)
        {
            object[] results = new object[] {(int)HttpStatusCode.InternalServerError, string.Empty};
            IDictionary<string, string[]>? Errors = new Dictionary<string, string[]>();

            switch (exception)
            {

                case BaseApplicationException baseException:

                    if (baseException.Errors.Any() && baseException.Errors.Count > 0)
                    {
                        Errors = baseException.Errors;
                    }

                    break;

                default:
                    break;
            }

            if (Errors.Any())
            {
                results = PrepareResults(
                        (int)HttpStatusCode.BadRequest, 
                        Errors
                    );
            }

            if ((string)results[1] == string.Empty)
            {
                results = PrepareResults(
                        (int)HttpStatusCode.BadRequest,
                        new Dictionary<string, string[]>() { [CommonConstans.UNEXPECTED_ERROR] = new string[] { exception.Message } }
                    );
            }

            context.Response.StatusCode = (int)results[0];
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync((string)results[1]);
        }

        private object[] PrepareResults(int statusCode, IDictionary<string, string[]> Errors)
        {
            return new object[] {
                (int)statusCode,
                JsonSerializer.Serialize(OperationResult.CreateErrorResult<EmptyResult>(Errors))
            };
        }
    }
}
