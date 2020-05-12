using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;



namespace AZ_BackEnd.Models
{
    public class Auto
    {
        public static string Issuer => "AZ";
        public static string Audience => "APIclients";
        public static int LifetimeInYears => 1;
        public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSecretKeyMustBeLoooooong"));

        internal static string GenerateToken(bool is_admin=false)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>
                {
                     new Claim(ClaimsIdentity.DefaultNameClaimType, "user"),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, is_admin?"admin":"guest")
                };
            ClaimsIdentity identity =
           new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
               ClaimsIdentity.DefaultRoleClaimType);
            //создаем токен
            var jwt = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Audience,
                    notBefore: now,
                    expires: now.AddYears(LifetimeInYears),
                    claims: identity.Claims,
                    signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)); ;
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
