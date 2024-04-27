using TwilioDotnetExample.Business.Abstract;
using TwilioDotnetExample.Business.Concrete;
using TwilioDotnetExample.Services.Abstract;
using TwilioDotnetExample.Services.Concrete;

namespace TwilioDotnetExample.Core.Extensions.Services
{
    public static class ServicesExtension
    {
        public static void InitializeTransient(this IServiceCollection services)
        {
            services.AddTransient<ITwilioService, TwilioService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
