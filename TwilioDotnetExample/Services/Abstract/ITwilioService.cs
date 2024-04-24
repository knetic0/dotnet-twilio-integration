using TwilioDotnetExample.Core.Utilities.Result;

namespace TwilioDotnetExample.Services.Abstract
{
    public interface ITwilioService
    {
        Task<IResultClient> SendVerificationSmsAsync(string phoneNumber);
        Task<IResultClient> ConfirmVerificationSmsAsync(string phoneNumber, string verificationCode);
    }
}
