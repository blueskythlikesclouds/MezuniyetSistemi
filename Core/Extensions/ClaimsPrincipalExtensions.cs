using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal principal, string claimType) =>
            principal?.FindAll(claimType)?.Select(x => x.Value).ToList();

        public static List<string> ClaimRoles(this ClaimsPrincipal principal) =>
            principal?.Claims(ClaimTypes.Role);
    }
}
