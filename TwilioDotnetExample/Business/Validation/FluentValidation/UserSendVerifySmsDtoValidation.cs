using FluentValidation;
using TwilioDotnetExample.Core.Constants;
using TwilioDotnetExample.Entities.DTOs;

namespace TwilioDotnetExample.Business.Validation.FluentValidation
{
    public class UserSendVerifySmsDtoValidation : AbstractValidator<UserSendVerifySmsDto>
    {
        public UserSendVerifySmsDtoValidation()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(Messages.PhoneNumberRequired)
                .Matches(@"^\+\d{1,3}\d{3}\d{3}\d{4}$")
                .WithMessage(Messages.InvalidPhoneNumberFormat);
        }
    }
}
