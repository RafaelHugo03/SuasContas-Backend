using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Services.Contracts;
using Application.Settings;
using Domain.enums;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(UserDTO dto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.SerialNumber, dto.Id.ToString()),
                    new Claim(ClaimTypes.Role, dto.Role.ToString())
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid GetIdFromToken(string token)
        {
            // var token = request.Headers["Authorization"].ToString().Split(" ")[1];
            var payload = new JwtSecurityTokenHandler().ReadJwtToken(token);
            
            var id = payload.Claims.First(claim => claim.Type == "certserialnumber").Value;
            return Guid.Parse(id);
        }

        public string PermittedForAllRoles()
        {
            return $"{Role.Admin.ToString()}, {Role.Basic.ToString()}, {Role.Premium.ToString()}";
        }
    }
}