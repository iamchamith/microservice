using App.SharedKernel.Extension;
using App.SharedKernel.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Utility
{
    public static class Extensions
    {
        public static List<string> ToErrorList(this IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                return identityResult.Errors.ToList()
                     .Select(p => p.Description).ToList();
            }
            return new List<string>();
        }
        public static bool IsOk(this int value)
        {
            return value.Is(200);
        }
        public static bool IsBad(this int value)
        {
            return value.Is(400);
        }
        public static bool IsInternalError(this int value)
        {
            return value.Is(500);
        }
        public static ViewMessage ToViewMessage(this object vb)
        {
            if (vb.IsNull())
                return new ViewMessage();
            else
                return vb as ViewMessage;
        }

        public static string ErrorsIdToMeaningFullError(this object message)
        {
            var output = "Something went wrong";
            var messageFormated = message.ToString().TrimAndToLower().Replace("\"", "");
            if (string.IsNullOrEmpty(messageFormated))
                return output;
            if (messageFormated.Equals(IdentityEnums.Errors.WhenLoginUserCannotFind.ToString().TrimAndToLower()))
                output = "User not found.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenLoginInvalidUserNameOrPassword.ToString().TrimAndToLower()))
                output = "Invalid Password.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenConfirmEmailThatNotFound.ToString().TrimAndToLower()))
                output = "Invalid email.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenConfirmEmailThatAlreadyValidated.ToString().TrimAndToLower()))
                output = "This email already validated.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenResetPasswordUserNorFound.ToString().TrimAndToLower()))
                output = "Invalid email.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString().TrimAndToLower()))
                output = "Authorization fail.Please login to the system again.";
            else if (messageFormated.Equals(IdentityEnums.Errors.WhenLoginEmailDoesNotConfirm.ToString().TrimAndToLower()))
                output = $"Please confirm your email before login.<a href='identity/sendemailconfirmation'>To send confirmation email</a>";
            
            return output.MakeThisRedable();
        }
    }
}
