using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Entities.DTOs;

namespace TwilioDotnetExample.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<IResultClient> UserSendVerificationSmsServiceAsync(UserSendVerifySmsDto args, CancellationToken cancellationToken);
        Task<IResultClient> UserConfirmVerificationSmsServiceAsync(UserConfirmVerifySmsDto args, CancellationToken cancellationToken);
    }
}
