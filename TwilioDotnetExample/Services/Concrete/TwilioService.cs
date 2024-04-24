using Twilio;
using Twilio.Rest.Verify.V2.Service;
using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Services.Abstract;
using TwilioDotnetExample.Services.Constants;
using TwilioDotnetExample.Services.DeserializationModels;

namespace TwilioDotnetExample.Services.Concrete
{
    public sealed class TwilioService : ITwilioService
    {
        private TwilioSettings? _twilioSettings;

        public TwilioService(IConfiguration configuration)
        {
            _twilioSettings = configuration.GetSection("TwilioSettings").Get<TwilioSettings>();
            TwilioClient.Init(_twilioSettings?.AccountSid, _twilioSettings?.AuthenticationKey);
        }

        public async Task<IResultClient> SendVerificationSmsAsync(string phoneNumber)
        {
            VerificationResource? verification = await VerificationResource.CreateAsync(to: phoneNumber, channel: _twilioSettings?.VerifyChannel, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verification.Status != TwilioStatus.Pending)
            {
                throw new Exception(Messages.SendVerificationSmsError);
            }
            
            return new Result(true, Messages.SendVerificationSmsSuccess);
        }

        public async Task<IResultClient> ConfirmVerificationSmsAsync(string phoneNumber, string verificationCode)
        {
            VerificationCheckResource? verificationCheck = await VerificationCheckResource.CreateAsync(to: phoneNumber, code: verificationCode, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verificationCheck.Status != TwilioStatus.Approved)
            {
                throw new Exception(Messages.SendVerificationSmsError);
            }

            return new Result(true, Messages.ConfirmVerificationSmsSuccess);
        }
    }
}
