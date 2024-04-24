using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwilioDotnetExample.Business.Validation.FluentValidation;
using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Entities.DTOs;
using TwilioDotnetExample.Services.Abstract;

namespace TwilioDotnetExample.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthenticationController(ITwilioService twilioService) : ControllerBase
    {
        private readonly ITwilioService _twilioService = twilioService;

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserSendVerificationSms))]
        public async Task<IResultClient> UserSendVerificationSms([FromBody] UserSendVerifySmsDto args)
        {
            UserSendVerifySmsDtoValidation validator = new();

            ValidationResult? result = validator.Validate(args);
            if(!result.IsValid)
            {
                return new DataResult<IEnumerable<ValidationFailure>>(result.Errors, false);
            }

            string phoneNumber = string.Concat(args.CountryCode, args.PhoneNumber);

            return await _twilioService.SendVerificationSmsAsync(phoneNumber);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserConfirmVerificationSms))]
        public async Task<IResultClient> UserConfirmVerificationSms([FromBody] UserConfirmVerifySmsDto args)
        {
            UserConfirmVerifySmsDtoValidation validation = new();

            ValidationResult? result = validation.Validate(args);
            if(!result.IsValid)
            {
                return new DataResult<IEnumerable<ValidationFailure>>(result.Errors, false);
            }

            string phoneNumber = string.Concat(args.CountryCode, args.PhoneNumber);

            return await _twilioService.ConfirmVerificationSmsAsync(phoneNumber, args.VerificationCode);
        }
    }
}
