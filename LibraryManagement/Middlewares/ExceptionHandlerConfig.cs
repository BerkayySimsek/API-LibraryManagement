using LibraryManagement.Exceptions.Type;
using Microsoft.AspNetCore.Diagnostics;

namespace LibraryManagement.Middlewares
{
    public class ExceptionHandlerConfig : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            if (exception is NotFoundException notFoundException)
            {
                await httpContext.Response.WriteAsync(notFoundException.Message);
                return false;
            }
            if (exception is BusinessException businessException)
            {
                await httpContext.Response.WriteAsync(businessException.Message);
                return false;
            }
            return true;
        }
    }
}
