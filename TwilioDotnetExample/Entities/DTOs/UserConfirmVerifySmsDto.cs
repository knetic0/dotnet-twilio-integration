using TwilioDotnetExample.Core.Entities;

namespace TwilioDotnetExample.Entities.DTOs
{
    public record UserConfirmVerifySmsDto(string PhoneNumber, string VerificationCode) : IDto
    {
    }
}
