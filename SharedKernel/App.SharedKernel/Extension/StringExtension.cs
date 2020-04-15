namespace App.SharedKernel.Extension
{
    public static class StringExtension
    {
        public static bool IsValidEmail(this string email) {
            return true;
        }
        public static bool IsValidPhoneNumber(this string phone) {
            return true;
        }
        public static string MakeThisRedable(this string message) {
            return message;
        }
    }
}
