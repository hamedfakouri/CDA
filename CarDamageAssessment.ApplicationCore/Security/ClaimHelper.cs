using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace CarDamageAssessment.ApplicationCore.Security
{
    public static class ClaimHelper
    {
        public static string GetUserRole()
        {

            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return identity.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Role).Value;
        }
        public static long GetUserId()
        {
            long userId = 0;
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claim = identity.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
                if (claim != null)
                    long.TryParse(claim.Value,out userId);
               
            }

            return userId;
        }

        public static List<Claim> GetUserClaims()
        {
            var claimsIdentity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return claimsIdentity.Claims.ToList();
        }
        public static ClaimsIdentity GetUserClaimsIdentity()
        {
            var claimsIdentity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return claimsIdentity;
        }
    }
}
