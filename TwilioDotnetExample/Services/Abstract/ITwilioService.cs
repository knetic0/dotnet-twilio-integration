using TwilioDotnetExample.Core.Utilities.Result;

namespace TwilioDotnetExample.Services.Abstract
{
    public interface ITwilioService
    {
        IResultClient SendVerificationSms(string phoneNumber);
        IResultClient ConfirmVerificationSms(string phoneNumber, string verificationCode);
    }
}
