using App.SharedKernel.Extension;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Utility
{
    public static class Extensions
    {
        public static List<string> ToErrorList(this IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                return identityResult.Errors.ToList()
                     .Select(p => p.Description).ToList();
            }
            return new List<string>();
        }
        public static bool IsOk(this int value) {
            return value.Is(200);
        }
        public static bool IsBad(this int value)
        {
            return value.Is(400);
        }
        public static bool IsInternalError(this int value)
        {
            return value.Is(500);
        }
    }
}
