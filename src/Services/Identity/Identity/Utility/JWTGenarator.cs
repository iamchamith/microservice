using Identity.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Utility
{
    public class JWTGenarator
    {
        public static string GenarateToken(IdentityUser identityUser, UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IdentityGlobalConfig.Jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
            new Claim(ClaimTypes.Sid,userInfo.UserId.ToString()),
                        new Claim(ClaimTypes.PrimarySid,identityUser.Id)
            };

            var token = new JwtSecurityToken(IdentityGlobalConfig.Jwt.Issue,
              IdentityGlobalConfig.Jwt.Issue, claims, expires: DateTime.Now.AddMinutes(AppConst.LOGIN_EXPIRE_AFTER),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
