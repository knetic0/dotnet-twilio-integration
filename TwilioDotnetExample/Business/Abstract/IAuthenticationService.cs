using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Entities.DTOs;

namespace TwilioDotnetExample.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IResultClient> UserSendVerificationSmsServiceAsync(UserSendVerifySmsDto args);
        Task<IResultClient> UserConfirmVerificationSmsServiceAsync(UserConfirmVerifySmsDto args);
    }
}
