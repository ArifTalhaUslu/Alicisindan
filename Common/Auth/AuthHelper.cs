using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Auth
{
    public static class AuthHelper
    {
        public static ClaimsPrincipal GetClaimsPrincipal(AuthModel user)
        {
            if (user != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.NameIdentifier));
               
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                return new ClaimsPrincipal(claimsIdentity);
            }
            else
            {
                return null;
            }
        }
    }
}
