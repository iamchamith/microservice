using Identity.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public interface IdentityService
    {
        IdentityApiController SetHttpContext(HttpContext context);
        Task<IActionResult> Login([FromBody] LoginViewModel model);
        Task<IActionResult> Logout();
        Task<IActionResult> Register([FromBody] RegisterViewModel model);
        Task<IActionResult> GetUserEmailConfirmationToken(string email);
        Task<IActionResult> ConfirmUserEmail(string email, string token);
        Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordViewModel model);
        Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model);
        Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model);
        Task<IActionResult> GetUserSettings();
    }
}
