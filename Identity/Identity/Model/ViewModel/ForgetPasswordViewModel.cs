using System.ComponentModel.DataAnnotations;
namespace Identity.Model.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
