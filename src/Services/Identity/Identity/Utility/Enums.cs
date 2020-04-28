namespace Identity.Utility
{
    public class Enums
    {
        public enum Errors
        {
            None,
            WhenLoginUserCannotFind = 1,
            WhenLoginEmailDoesNotConfirm,
            WhenLoginInvalidUserNameOrPassword,

            WhenConfirmEmailThatNotFound,
            WhenConfirmEmailThatAlreadyValidated,
    
            WhenAuthorizationUserNotFound,

            WhenResetPasswordUserNorFound
        }
    }
}
