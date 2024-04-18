using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitectureTemplate.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IDateTime _dateTime;
        public TokenService(IConfiguration config, IDateTime dateTime)
        {
            _config = config;
            _dateTime = dateTime;
        }

        public Task<TokenServiceResult> GenerateTokenAsync(IEnumerable<Claim> claims, long? expireDate)
        {
            try
            {
                // ALGORITHM & TOKEN TYPE
                var secretKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var securityKey = new SymmetricSecurityKey(secretKey!);
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                DateTime ExpireDate;
                if (expireDate.HasValue && expireDate.Value > 0)
                    ExpireDate = expireDate.ToDateTime();

                else
                    ExpireDate = _dateTime.DateTimeNow.AddHours(1);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    claims,
                    expires: ExpireDate,
                    signingCredentials: signingCredentials);

                var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

                return Task.FromResult(new TokenServiceResult() { IsSuccess = true, Token = encodetoken });
            }

            catch (Exception ex)
            {
                // LOG
                return Task.FromResult(new TokenServiceResult() { Exception = ex });
            }
        }

        public Task<TokenServiceResult> RefreshTokenAsync(User user, long? expireDate = null)
        {
            throw new NotImplementedException();
        }
    }
}
