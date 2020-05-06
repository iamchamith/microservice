namespace App.SharedKernel.Utilities
{
    public class DataAnnotationsConst
    {
        public const int IDENTITY_LENGTH = 50;
        public const int NAME_LENGTH = 50;
        public const int DESCRIPTION_LENGTH = 500;
        public const int IMAGE_LENGTH = 100;
        public const int EMAIL_LENGTH = 50;
        public const int PHONE_LENGTH = 50;
        public const int PASSWORD_LENGTH = 10;
        public const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    }
}
