using BuberDinnerApp.Application.Common.interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinnerApp.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
                SecurityAlgorithms.HmacSha256
                );
            var clims = new[]
            {
                 new Claim (JwtRegisteredClaimNames.Sub,userId.ToString()),
                 new Claim (JwtRegisteredClaimNames.GivenName,firstName),
                 new Claim (JwtRegisteredClaimNames.FamilyName,lastName),
                 new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
             };
            var securityToken = new JwtSecurityToken(
                issuer: "testissuer",
                expires: DateTime.Now.AddDays(2),
                claims: clims,
                signingCredentials: siginingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
