using App.SharedKernel.Extension;
using Identity.Model.ViewModel;
using Identity.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    public class IdentityController : IdentityBaseController
    {
        private readonly IdentityService _identityService;
        IEmailService _emailService { get; set; }
        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        #region register/login/logout
        public async Task<IActionResult> Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(UserSettings));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            ViewData["message"] = string.Empty;
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Login(model));
            if (result.Item1.IsOk())
                return RedirectToAction(nameof(UserSettings));
            else if (result.Item1.IsOk())
                ViewData["message"] = result.Item2;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(UserSettings));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Register(model));
            if (result.Item1.IsOk())
            {
                var result2 = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserEmailConfirmationToken(model.Email));
                if (result2.Item1.IsOk())
                {
                    ViewData["message"] = "Registration success.";
                    ViewData["token"] = Url.Action("ConfirmEmail", "Identity", new { email = model.Email, token = result2.Item2 });
                }
                else
                {
                    ViewData["message"] = result2.Item2;
                }
            }
            else
                ViewData["message"] = result.Item2;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendEmailConfirmation(string email = "")
        {
            return View(nameof(SendEmailConfirmation), email);
        }

        [HttpPost, ActionName("SendEmailConfirmation")]
        public async Task<IActionResult> SendEmailConfirmationSubmit(string email)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserEmailConfirmationToken(email));
            if (result.Item1.IsOk())
                ViewData["token"] = Url.Action(nameof(ConfirmEmail), "identity", new { userId = email, token = result.Item2 });
            else
                ViewData["message"] = result.Item2;
            return View(nameof(SendEmailConfirmation), email);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ConfirmUserEmail(email, token));
            ViewData["message"] = result.Item1.IsOk() ? "Email Confirmed success" : result.Item2;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Logout());
            if (result.Item1.IsOk())
                return View("Login");
            else
                return BadRequest(result.Item2);
        }
        #endregion


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordViewModel model)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ChangePassword(model));
            ViewData["message"] = result.Item1.IsOk() ? "Password updated" : result.Item2;
            return View();
        }

        #region forget and reset password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword([FromForm]ForgetPasswordViewModel model)
        {
            ViewData["message"] = string.Empty;
            ViewData["token"] = string.Empty;

            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ForgetPassword(model));
            if (result.Item1.IsOk())
            {
                ViewData["message"] = "Please Check your Email ";
                ViewData["token"] = Url.Action(nameof(ResetPassword), "Identity", new { email = model.Email, token = result.Item1 }, Request.Scheme);
            }
            else
                ViewData["message"] = result.Item2;
            return View();
        }

        [HttpGet, Authorize]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ResetPassword(model));
            ViewData["message"] = result.Item1.IsOk() ? "Password changed" : result.Item2;
            return View("login");
        }
        #endregion


        [HttpGet, Authorize]
        public async Task<IActionResult> UserSettings()
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserSettings());
            if (result.Item1.IsOk())
                return View(result.Item2);
            else
                return RenderErrorView(result.Item1);
        }

        [HttpPut]
        public IActionResult UserSettings([FromForm]UserSettingViewModel model)
        {
            return View();
        }
    }
}
