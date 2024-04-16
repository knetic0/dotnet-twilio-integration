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

        public IResultClient SendVerificationSms(string phoneNumber)
        {
            VerificationResource? verification = VerificationResource.Create(to: phoneNumber, channel: _twilioSettings?.VerifyChannel, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verification.Status != TwilioStatus.Pending)
            {
                throw new Exception(Messages.SendVerificationSmsError);
            }
            
            return new Result(true, Messages.SendVerificationSmsSuccess);
        }

        public IResultClient ConfirmVerificationSms(string phoneNumber, string verificationCode)
        {
            VerificationCheckResource? verificationCheck = VerificationCheckResource.Create(to: phoneNumber, code: verificationCode, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verificationCheck.Status != TwilioStatus.Approved)
            {
                throw new Exception(Messages.SendVerificationSmsError);
            }

            return new Result(true, Messages.ConfirmVerificationSmsSuccess);
        }
    }
}
