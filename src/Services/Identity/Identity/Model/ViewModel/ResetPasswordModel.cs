using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required, RegularExpression(DataAnnotationsConst.EMAIL_REGEX), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Token { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
