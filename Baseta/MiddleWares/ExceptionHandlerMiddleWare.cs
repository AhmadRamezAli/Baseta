using Baseta.Exceptions;
using System.Net;
using System.Text.Json;

namespace Baseta.MiddleWares
{
    public class ExceptionHandlerMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (PipeLineException ex)
            {
                // 400 - Bad Request
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Error = "Validation Error",
                    Details = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));


            }
            catch (Exception ex)
            {
                // 500 - Internal Server Error
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Error = "Internal Server Error",
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

            }


        }
    }
}
