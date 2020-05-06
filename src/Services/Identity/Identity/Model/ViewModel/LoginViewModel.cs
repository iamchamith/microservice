using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.EmailAddress), StringLength(DataAnnotationsConst.EMAIL_LENGTH),
            RegularExpression(DataAnnotationsConst.EMAIL_REGEX)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), StringLength(DataAnnotationsConst.PASSWORD_LENGTH)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
