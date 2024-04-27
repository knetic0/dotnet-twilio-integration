using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwilioDotnetExample.Business.Abstract;
using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Entities.DTOs;

namespace TwilioDotnetExample.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserSendVerificationSms))]
        public async Task<IResultClient> UserSendVerificationSms([FromBody] UserSendVerifySmsDto args, CancellationToken cancellationToken)
        {
            return await _authenticationService.UserSendVerificationSmsServiceAsync(args, cancellationToken);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserConfirmVerificationSms))]
        public async Task<IResultClient> UserConfirmVerificationSms([FromBody] UserConfirmVerifySmsDto args, CancellationToken cancellationToken)
        {
            return await _authenticationService.UserConfirmVerificationSmsServiceAsync(args, cancellationToken);
        }
    }
}
