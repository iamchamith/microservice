using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;
namespace Identity.Model.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress), StringLength(DataAnnotationsConst.EMAIL_LENGTH),
         RegularExpression(DataAnnotationsConst.EMAIL_REGEX)]
        public string Email { get; set; }
        public string CallbackUrl { get; private set; } = "";

        public ForgetPasswordViewModel SetCallbackUrl(string url) {
            CallbackUrl = url;
            return this;
        }
    }
}
