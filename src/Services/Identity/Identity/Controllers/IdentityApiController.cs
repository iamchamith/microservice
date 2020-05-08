using System;
using System.Security.Claims;
using System.Threading.Tasks;
using App.SharedKernel.Exception;
using App.SharedKernel.Extension;
using App.SharedKernel.ValueObjects;
using Identity.Model.Entities;
using Identity.Model.Infastructure;
using Identity.Model.ViewModel;
using Identity.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.SharedKernel.Messaging.Email;
using App.SharedKernel;

namespace Identity.Controllers
{
    [Route("api/identity")]
    public class IdentityApiController : Controller, IdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<string> _logger;
        private readonly IdentityContext _dbContext;
        IEmailService _emailService { get; set; }
        HttpContext _httpContext;
        ClaimsPrincipal _user;
        public IdentityApiController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IEmailService emailService,
            IdentityContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _dbContext = dbContext;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IdentityApiController SetHttpContext(HttpContext context)
        {
            _httpContext = context;
            _user = _httpContext.User;
            return this;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                throw new Exception("db fail");
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user.IsNull())
                    return BadRequest(IdentityEnums.Errors.WhenLoginUserCannotFind.ToString());
                else if (!user.EmailConfirmed)
                    return BadRequest(IdentityEnums.Errors.WhenLoginEmailDoesNotConfirm.ToString());

                var result = await _signInManager.PasswordSignInAsync(model.Email,
                                   model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var userInfo = await _dbContext.UserInfo.SingleOrDefaultAsync(p => p.UserId == user.Id);
                    var token = JWTGenarator.GenarateToken(user, userInfo);
                    return Ok(token);
                }
                else
                    return BadRequest(IdentityEnums.Errors.WhenLoginInvalidUserNameOrPassword.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Email.TrimAndToLower(),
                    Email = model.Email.TrimAndToLower()
                };
                IdentityResult result = null;
                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        result = await _userManager.CreateAsync(user, model.Password);
                        if (!result.Succeeded)
                            return BadRequest(result.ToErrorList());
                        _dbContext.Add(new UserInfo(user.Id, user.Email).SetDefaultAddress().SetName(model.Name));
                        await _dbContext.SaveChangesAsync();
                        transaction.Commit();
                        return Ok();
                    }
                    catch (System.Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("users/{email}/confirmemail"), AllowAnonymous]
        public async Task<IActionResult> GetUserEmailConfirmationToken(string email, string callback = "{0}users/{1}/confirmemail?token={2}")
        {
            try
            {
                email = email.TrimAndToLower();
                var user = await _userManager.FindByEmailAsync(email);
                if (user.IsNull())
                    return BadRequest(IdentityEnums.Errors.WhenConfirmEmailThatNotFound.ToString());
                else if (user.EmailConfirmed)
                    return BadRequest(IdentityEnums.Errors.WhenConfirmEmailThatAlreadyValidated.ToString());

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                await _emailService.SendAsync(new EmailParam("Confirm Email By Amazon.com")
                    .AddSendTo(email)
                    .SetBody(
                    EmailHelper.AddParagraph("Please Confirm your email by clicking fologing link"),
                      EmailHelper.AddLink(string.Format(callback, GlobalConfig.HostModules[App.SharedKernel.Model.Enums.Modules.Identity]
                      , email, token), "Click her")));
                return Ok("token_sent");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("users/{email}/confirmemail"), AllowAnonymous]
        public async Task<IActionResult> ConfirmUserEmail(string email, string token)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user.IsNull())
                    return BadRequest(IdentityEnums.Errors.WhenConfirmEmailThatNotFound.ToString());
                else if (user.EmailConfirmed)
                    return BadRequest(IdentityEnums.Errors.WhenConfirmEmailThatAlreadyValidated.ToString());

                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                    return Ok();
                else
                    return BadRequest(result.ToErrorList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("users/password/forget"), AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user.IsNull())
                    return BadRequest(IdentityEnums.Errors.WhenResetPasswordUserNorFound.ToString());
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                await _emailService.SendAsync(new EmailParam("Reset password Amazon.com")
                 .AddSendTo(model.Email)
                 .SetBody(
                 EmailHelper.AddParagraph("Please click below link for reset password."),
                   EmailHelper.AddLink(string.Format(model.CallbackUrl, GlobalConfig.HostModules[App.SharedKernel.Model.Enums.Modules.Identity]
                   , model.Email, token), "Click her")));
                return Ok(token);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("users/password/reset"), AllowAnonymous]  
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user.IsNull())
                    return BadRequest(IdentityEnums.Errors.WhenResetPasswordUserNorFound.ToString());

                var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (!resetPassResult.Succeeded)
                    return BadRequest(resetPassResult.ToErrorList());
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("users/password/change"), Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_user);
                if (user.IsNull())
                    return Unauthorized(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString());
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword ?? "", model.NewPassword ?? "");
                if (result.Succeeded)
                    return Ok();
                else
                    return BadRequest(result.ToErrorList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("users/myinfo"), Authorize]
        public async Task<IActionResult> GetUserSettings()
        {
            try
            {
                if (_user.IsNull())
                    return Unauthorized(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString());
                var userid = _user.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userid.IsNull())
                    return Unauthorized(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString());
                var userInfo = await _dbContext.UserInfo.AsNoTracking().SingleOrDefaultAsync(p => p.UserId == userid);
                var userIdentity = await _userManager.GetUserAsync(_user);
                if (userInfo.IsNull() || userIdentity.IsNull())
                    return Unauthorized(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString());
                return Ok(new UserSettingViewModel(userIdentity, userInfo));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("users/myinfo"), Authorize]
        public async Task<IActionResult> UpdateUserSettings([FromBody]UserSettingViewModel model)
        {
            try
            {
                if (_user.IsNull())
                    return Unauthorized(IdentityEnums.Errors.WhenAuthorizationUserNotFound.ToString());
                var userid = _user.FindFirstValue(ClaimTypes.NameIdentifier);
                var userInfo = await _dbContext.UserInfo.AsTracking().SingleOrDefaultAsync(p => p.UserId == userid);
                if (userInfo.IsNull())
                    throw new NotFoundException($"User {userid} not found");

                userInfo.UpdateInfo(new PersonName(model.FirstName, model.MiddleName, model.LastName), model.PhoneNumber,
                    new Address(model.City, model.Street, model.Number));
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpGet("test/email")]
        public async Task<IActionResult> SendTestEmail(string email)
        {
            try
            {
                await _emailService.SendAsync(new EmailParam("Confirm Email By Amazon.com")
          .AddSendTo(email)
          .SetBody(
          EmailHelper.AddParagraph("Please Confirm your email by clicking fologing link")));
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        [HttpGet("test/loggs")]
        public async Task<IActionResult> NLoggerTest() {

            throw new Exception("something went wrong");
        }
    }
}
