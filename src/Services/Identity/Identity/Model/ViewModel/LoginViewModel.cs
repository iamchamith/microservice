using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required, DataType(DataType.EmailAddress), StringLength(DataAnnotationsConst.EMAIL_LENGTH)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), StringLength(50)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
