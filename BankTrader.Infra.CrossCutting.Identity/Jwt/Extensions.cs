using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace BankTrader.Infra.CrossCutting.Identity.Jwt
{
    internal static class Extensions
    {
        public static void RemoveRefreshToken(this ICollection<Claim> claims)
        {
            var refreshToken = claims.FirstOrDefault(f => f.Type == "LastRefreshToken");
            if (refreshToken is not null)
                claims.Remove(refreshToken);
        }

        public static string? GetJwtId(this ClaimsIdentity principal)
        {
            return principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        }
    }
}
