using FluentValidation.Results;
using TwilioDotnetExample.Business.Abstract;
using TwilioDotnetExample.Business.Validation.FluentValidation;
using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Entities.DTOs;
using TwilioDotnetExample.Services.Abstract;

namespace TwilioDotnetExample.Business.Concrete
{
    public class AuthenticationService(ITwilioService twilioService) : IAuthenticationService
    {
        private readonly ITwilioService _twilioService = twilioService;

        public async Task<IResultClient> UserSendVerificationSmsServiceAsync(UserSendVerifySmsDto args)
        {
            UserSendVerifySmsDtoValidation validation = new();

            ValidationResult? result = validation.Validate(args);
            if(!result.IsValid)
            {
                return new DataResult<IEnumerable<ValidationFailure>>(result.Errors, false);
            }

            string phoneNumber = string.Concat(args.CountryCode, args.PhoneNumber);

            return await _twilioService.SendVerificationSmsAsync(phoneNumber);
        }

        public async Task<IResultClient> UserConfirmVerificationSmsServiceAsync(UserConfirmVerifySmsDto args)
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
