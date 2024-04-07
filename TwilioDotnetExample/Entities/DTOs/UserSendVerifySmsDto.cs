using TwilioDotnetExample.Core.Entities;

namespace TwilioDotnetExample.Entities.DTOs
{
    public record UserSendVerifySmsDto(string PhoneNumber) : IDto
    {
    }
}
