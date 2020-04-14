using Abp.Runtime.Caching;
using App.SharedKernel.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace App.SharedKernel.Attribute
{
    public class AuthorizePermissionAttribute : TypeFilterAttribute
    {
        public AuthorizePermissionAttribute(params string[] values)
            : base(typeof(AuthorizePermissionFilter))
        {
            var lst = values.Select(item => item.ToString()).ToList();
            Arguments = new object[] { lst };
        }
        public AuthorizePermissionAttribute(List<string> values = null)
            : base(typeof(AuthorizePermissionFilter))
        {
            var lst = values.Select(item => item.ToString()).ToList();
            Arguments = new object[] { lst };
        }
        public AuthorizePermissionAttribute()
          : base(typeof(AuthorizePermissionFilter))
        {
            Arguments = new object[] { };
        }
    }
    public class AuthorizePermissionFilter : IAuthorizationFilter
    {

        public List<string> _roles { get; }
        public ICacheManager _cacheManager { get; }
        public IHttpContextAccessor _accessor { get; }
        public AuthorizePermissionFilter(List<string> roles, ICacheManager cacheManager,
            IHttpContextAccessor accessor)
        {
            _roles = roles;
            _cacheManager = cacheManager;
            _accessor = accessor;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {

                var token = context.HttpContext.Request.Headers["Authorization"];
                if (token.Count.IsZero())
                    context.Result = new UnauthorizedResult();

                var clist = context.HttpContext.User.Claims.ToList();
                var tenantid = clist.FirstOrDefault(p => p.Type == "tenant")?.Value;
                var issuperadmin = clist.FirstOrDefault(p => p.Type == "issuperadmin")?.Value;
                var sessionId = clist.FirstOrDefault(p => p.Type == "sessionId")?.Value;
                var ip = clist.FirstOrDefault(p => p.Type == "ip")?.Value;


            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
