using App.SharedKernel.Model;

namespace Identity.Utility
{
    public class IdentityEnums : Enums
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
