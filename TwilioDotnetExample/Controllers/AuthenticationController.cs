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
        private ITwilioService _twilioService = twilioService;

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserSendVerificationSms))]
        public IResultClient UserSendVerificationSms([FromBody] UserSendVerifySmsDto args)
        {
            try
            {
                UserSendVerifySmsDtoValidation validator = new();

                ValidationResult? result = validator.Validate(args);
                if(!result.IsValid)
                {
                    return new DataResult<IEnumerable<ValidationFailure>>(result.Errors, false);
                }

                return _twilioService.SendVerificationSms(args.PhoneNumber);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(UserConfirmVerificationSms))]
        public IResultClient UserConfirmVerificationSms([FromBody] UserConfirmVerifySmsDto args)
        {
            try
            {
                UserConfirmVerifySmsDtoValidation validation = new();

                ValidationResult? result = validation.Validate(args);
                if(!result.IsValid)
                {
                    return new DataResult<IEnumerable<ValidationFailure>>(result.Errors, false);
                }

                return _twilioService.ConfirmVerificationSms(args.PhoneNumber, args.VerificationCode);
            }
            catch(Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}