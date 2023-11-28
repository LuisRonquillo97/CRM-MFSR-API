using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Security.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Security.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateToken(User user, string jwtConfigutation = "")
        {
            List<JwtConfiguration> configuration = JsonConvert.DeserializeObject<List<JwtConfiguration>>(jwtConfigutation);
            // Generamos un token según los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };
            List<Permission> permissions = new();

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleId.ToString()));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.First(x => x.Key.Equals("Key")).Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.First(x=>x.Key.Equals("Issuer")).Value,
                audience: configuration.First(x => x.Key.Equals("Audience")).Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public static object ValidateToken(ClaimsPrincipal user)
        {
            return new
            {
                Claims = user.Claims.Select(s => new
                {
                    s.Type,
                    s.Value
                }).ToList(),
                user.Identity.Name,
                user.Identity.IsAuthenticated,
                user.Identity.AuthenticationType
            };
        }
    }
}

