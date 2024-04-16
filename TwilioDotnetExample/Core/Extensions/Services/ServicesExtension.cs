using TwilioDotnetExample.Services.Abstract;
using TwilioDotnetExample.Services.Concrete;

namespace TwilioDotnetExample.Core.Extensions.Services
{
    public static class ServicesExtension
    {
        public static void InitializeTransient(this IServiceCollection services)
        {
            services.AddTransient<ITwilioService, TwilioService>();
        }
    }
}
