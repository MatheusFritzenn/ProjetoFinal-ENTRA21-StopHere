using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Functions
{
    public static class CookiesHelper
    {
        public static CookieUser GetCookieData(ClaimsPrincipal identity)
        {
            List<Claim> claims = identity.Claims.ToList();
            return new CookieUser()
            {
                Nome = claims[0].Value,
                Email = claims[1].Value,
                ID = int.Parse(claims[2].Value)
            };
        }
    }
}