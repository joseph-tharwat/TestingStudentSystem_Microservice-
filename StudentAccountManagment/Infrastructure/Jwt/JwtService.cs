using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentAccountManagment.Infrastructure.Jwt
{
    public class JwtService
    {
        private readonly IOptions<JwtOptions> jwtOptions;

        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Value.Issuer,
                audience: jwtOptions.Value.Audiance,
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddHours(1));

            var jwtToken = (new JwtSecurityTokenHandler()).WriteToken(token);
            return jwtToken;
        }
    }
}
