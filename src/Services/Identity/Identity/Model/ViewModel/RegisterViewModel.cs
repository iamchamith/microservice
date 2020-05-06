using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model.ViewModel
{
    public class RegisterViewModel
    {
        [Required, DataType(DataType.EmailAddress), StringLength(DataAnnotationsConst.EMAIL_LENGTH),
            RegularExpression(DataAnnotationsConst.EMAIL_REGEX)]
        public string Email { get; set; }
        [Required, DataType(DataType.Text), StringLength(DataAnnotationsConst.NAME_LENGTH)]
        public string Name { get; set; }
        [Required, DataType(DataType.Password), StringLength(DataAnnotationsConst.PASSWORD_LENGTH)]
        public string Password { get; set; }
    }
}
