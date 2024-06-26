﻿using Twilio;
using Twilio.Rest.Verify.V2.Service;
using TwilioDotnetExample.Core.Utilities.Result;
using TwilioDotnetExample.Services.Abstract;
using TwilioDotnetExample.Services.Constants;
using TwilioDotnetExample.Services.DeserializationModels;

namespace TwilioDotnetExample.Services.Concrete
{
    public sealed class TwilioService : ITwilioService
    {
        private readonly TwilioSettings? _twilioSettings;

        public TwilioService(IConfiguration configuration)
        {
            _twilioSettings = configuration.GetSection(nameof(TwilioSettings)).Get<TwilioSettings>();
            TwilioClient.Init(_twilioSettings?.AccountSid, _twilioSettings?.AuthenticationKey);
        }

        public async Task<IResultClient> SendVerificationSmsAsync(string phoneNumber)
        {
            VerificationResource? verification = await VerificationResource.CreateAsync(to: phoneNumber, channel: _twilioSettings?.VerifyChannel, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verification.Status != TwilioStatus.Pending)
            {
                return new Result(false, Messages.SendVerificationSmsError);
            }
            
            return new Result(true, Messages.SendVerificationSmsSuccess);
        }

        public async Task<IResultClient> ConfirmVerificationSmsAsync(string phoneNumber, string verificationCode)
        {
            VerificationCheckResource? verificationCheck = await VerificationCheckResource.CreateAsync(to: phoneNumber, code: verificationCode, pathServiceSid: _twilioSettings?.VerificationServiceSid);

            if (verificationCheck.Status != TwilioStatus.Approved)
            {
                return new Result(false, Messages.ConfirmVerificationSmsError);
            }

            return new Result(true, Messages.ConfirmVerificationSmsSuccess);
        }
    }
}
