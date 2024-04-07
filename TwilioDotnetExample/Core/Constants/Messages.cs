namespace TwilioDotnetExample.Core.Constants
{
    public static class Messages
    {
        public static string PhoneNumberRequired = "Phone Number is required!";
        public static string InvalidPhoneNumberFormat = "Invalid phone number format. Use +XXXXXXXXXXXXX format.";

        public static string VerificationCodeRequired = "Verification Code is required!";
        public static string VerificationCodeLengthError = $"Verification Code must be {Variables.ConfirmationVerificationSmsCodeLength} digits long!";
    }
}
