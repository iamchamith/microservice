using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password), Required, StringLength(DataAnnotationsConst.PASSWORD_LENGTH)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password), Required, StringLength(DataAnnotationsConst.PASSWORD_LENGTH)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password), Required, StringLength(DataAnnotationsConst.PASSWORD_LENGTH),
            Compare(nameof(NewPassword), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
