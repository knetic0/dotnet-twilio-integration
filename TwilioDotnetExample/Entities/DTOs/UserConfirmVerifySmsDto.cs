using TwilioDotnetExample.Core.Entities;

namespace TwilioDotnetExample.Entities.DTOs
{
    public record UserConfirmVerifySmsDto(string CountryCode, string PhoneNumber, string VerificationCode) : IDto
    {
    }
}
