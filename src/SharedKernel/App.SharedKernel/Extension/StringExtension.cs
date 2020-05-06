using App.SharedKernel.Utilities;
using System.Text.RegularExpressions;

namespace App.SharedKernel.Extension
{
    public static class StringExtension
    {
        public static bool IsValidEmail(this string email)
        {
            if (email.IsNull())
                return false;
            return Regex.Match(email, DataAnnotationsConst.EMAIL_REGEX, RegexOptions.IgnoreCase).Success;
        }
        public static bool IsValidPhoneNumber(this string phone)
        {
            return true;
        }
        public static string MakeThisRedable(this string message)
        {
            return message;
        }
        public static string TrimAndToLower(this string text)
        {
            return (text.IsNull()) ? "" : text.Trim().ToLower();
        }
    }
}
