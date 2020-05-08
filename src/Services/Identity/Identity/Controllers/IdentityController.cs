using App.SharedKernel.Extension;
using App.SharedKernel.Messaging.Email;
using Identity.Model.ViewModel;
using Identity.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(UserSettings));
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Login(model));
            if (result.Item1.IsOk())
            {
                CookieOptions option = new CookieOptions { Expires = DateTime.Now.AddMinutes(AppConst.LOGIN_EXPIRE_AFTER) };
                Response.Cookies.Append("bearer", result.Item2.ToString(), option);
                return RedirectToAction(nameof(UserSettings));
            }
            else
                SetViewMessage(false, result.Item2.ErrorsIdToMeaningFullError());
            return View();
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction(nameof(UserSettings));
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Register(model));
            if (result.Item1.IsOk())
            {
                var result2 = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserEmailConfirmationToken(model.Email));
                if (result2.Item1.IsOk())
                    SetViewMessage(true, "Registration success.Please confirm your email address");
                else
                    SetViewMessage(false, result2.Item2.ErrorsIdToMeaningFullError());
            }
            else
                SetViewMessage(false, result.Item2.ErrorsIdToMeaningFullError());
            return View();
        }
        #region confirm email
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> SendEmailConfirmation(string email = "")
        {
            return View(nameof(SendEmailConfirmation), email);
        }

        [HttpPost, ActionName("SendEmailConfirmation"), AllowAnonymous]
        public async Task<IActionResult> SendEmailConfirmationSubmit(string email)
        {
            email = email ?? "".TrimAndToLower();
            if (string.IsNullOrEmpty(email) || !email.IsValidEmail())
            {
                SetViewMessage(false, "Invalid email.");
                return View(nameof(SendEmailConfirmation), email);
            }
            var relativeUrl = "{0}/identity/" + nameof(ConfirmEmail) + "?" + "email={1}&token={2}";
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserEmailConfirmationToken(email, relativeUrl));
            if (result.Item1.IsOk())
                SetViewMessage(true, "Confirmation token sent to your email.");
            else
                SetViewMessage(false, result.Item2.ErrorsIdToMeaningFullError());
            return View(nameof(SendEmailConfirmation), email);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ConfirmUserEmail(email, token));
            SetViewMessage(result.Item1.IsOk(), result.Item1.IsOk() ? $"Email Confirmed success.{EmailHelper.AddLink($"identity/{nameof(Login)}", "Please login to the system.")}" : result.Item2.ToString());
            return View();
        }
        #endregion
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).Logout());
            if (result.Item1.IsOk())
                return View("Login");
            else
                return BadRequest(result.Item2);
        }
        #endregion

        #region forget and reset password
        [HttpGet, AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromForm]ForgetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.SetCallbackUrl("{0}/ResetPassword?email={1}&token={2}");
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ForgetPassword(model));
            if (result.Item1.IsOk())
                SetViewMessage(true, "Token sent.Please Check your Email.");
            else
                SetViewMessage(false, result.Item2.ErrorsIdToMeaningFullError());
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (email.IsValidEmail() || string.IsNullOrEmpty(token))
                SetViewMessage(false, "Invalid email or token");
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ResetPassword(model));
            SetViewMessage(result.Item1.IsOk(), result.Item1.IsOk() ? "Password changed.Login to the application." : result.Item2.ToString());
            return View(model);
        }
        #endregion

        #region change password
        [HttpGet, Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).ChangePassword(model));
            SetViewMessage(result.Item1.IsOk(), result.Item1.IsOk() ? "Password updated" : result.Item2.ToString().ErrorsIdToMeaningFullError());
            return View(model);
        }
        #endregion

        #region update user
        [HttpGet, Authorize]
        public async Task<IActionResult> UserSettings()
        {
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).GetUserSettings());
            if (result.Item1.IsOk())
                return View(result.Item2);
            else
                return RenderErrorView(result.Item1);
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UserSettings([FromForm]UserSettingViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = ActionResultFilter(await _identityService.SetHttpContext(HttpContext).UpdateUserSettings(model));
            if (result.Item1.IsOk())
                SetViewMessage(true, "Update success.");
            else
                SetViewMessage(false,result.Item1.ToString());
                return View(model);
        }
        #endregion

    }
}
