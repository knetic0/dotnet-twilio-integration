using FluentValidation;
using TwilioDotnetExample.Core.Constants;
using TwilioDotnetExample.Entities.DTOs;

namespace TwilioDotnetExample.Business.Validation.FluentValidation
{
    public class UserConfirmVerifySmsDtoValidation : AbstractValidator<UserConfirmVerifySmsDto>
    {
        public UserConfirmVerifySmsDtoValidation()
        {
            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .WithMessage(Messages.CountryCodeRequired)
                .Matches(@"^\+(?:[0-9]?){1,3}$")
                .WithMessage(Messages.InvalidCountryCode);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(Messages.PhoneNumberRequired)
                .Length(Variables.PhoneNumberLength)
                .WithMessage(Messages.PhoneNumberLengthError)
                .Matches(@"^\d{3}\d{3}\d{4}$")
                .WithMessage(Messages.InvalidPhoneNumberFormat);

            RuleFor(x => x.VerificationCode)
                .NotEmpty()
                .WithMessage(Messages.VerificationCodeRequired)
                .Length(Variables.ConfirmationVerificationSmsCodeLength)
                .WithMessage(Messages.VerificationCodeLengthError);
        }
    }
}
