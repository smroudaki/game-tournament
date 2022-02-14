using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _jwtSecret;

        public JwtService(IConfiguration configuration)
        {
            _jwtSecret = configuration.GetValue<string>("JWT:Secret").ToString();
        }

        public Task<string> GenerateToken(User user, DateTime expireDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserGuid.ToString()),
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Email, user.Email ?? "")
                }),
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(token);
            return Task.FromResult(result);
        }
    }
}
