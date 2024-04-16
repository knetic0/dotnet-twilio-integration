using TwilioDotnetExample.Core.Middlewares;

namespace TwilioDotnetExample.Core.Extensions.WebApp
{
    public static class MiddlewareExtension
    {
        public static void AddExceptionHandling(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
