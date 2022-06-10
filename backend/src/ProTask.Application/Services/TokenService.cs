using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;

namespace ProTask.Application.Services
{
    public class TokenService : ITokenService
    {
        protected readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));;
        }

        public TokenResponseDTO Generate(string userName, IEnumerable<string> userRoles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Generate private key
            var privateKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]));
            // Signung credencials
            var credencials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256Signature);
            // Generate claims
            var claims = GenerateClaims(userName, userRoles);
            // Token expiration date
            var expirationDate = DateTime.UtcNow.AddHours(24);
            // Generate token descriptor
            var securityTokenDescriptor = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                SigningCredentials = credencials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
            };
            // Generate token
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            // Create the token response
            return new TokenResponseDTO(tokenHandler.WriteToken(securityToken), expirationDate);
        }

        private Claim[] GenerateClaims(string userName, IEnumerable<string> userRoles)
        {
            return new Claim[]{
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, string.Join(";", userRoles.Select(r => r))),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
        }
    }
}