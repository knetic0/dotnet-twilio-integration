namespace TwilioDotnetExample.Core.Constants
{
    public static class Messages
    {
        public static string CountryCodeRequired = "Country code is required!";
        public static string InvalidCountryCode = "Invalid country code format. The length must be between {1, 3}!";

        public static string PhoneNumberRequired = "Phone Number is required!";
        public static string PhoneNumberLengthError = $"Your phone number must be {Variables.PhoneNumberLength} length";
        public static string InvalidPhoneNumberFormat = "Invalid phone number format. Use +XXXXXXXXXXXXX format.";

        public static string VerificationCodeRequired = "Verification Code is required!";
        public static string VerificationCodeLengthError = $"Verification Code must be {Variables.ConfirmationVerificationSmsCodeLength} digits long!";
    }
}
