using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using CleanArchitectureReferenceTemplate.Infrastructure.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Services
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

        public Task<TokenServiceResult> GenerateTokenAsync(User user, long? expireDate)
        {
            try
            {
                // ALGORITHM & TOKEN TYPE
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
                };

                DateTime ExpireDate;
                if (expireDate.HasValue && expireDate.Value > 0)
                    ExpireDate = expireDate.ToDateTime();

                else
                    ExpireDate = _dateTime.DateTimeNow;

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Issuer"],
                    claims,
                    expires: ExpireDate,
                    signingCredentials: credentials);

                var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

                return Task.FromResult(new TokenServiceResult() { IsSuccess = true, Token = encodetoken });
            }

            catch (Exception ex)
            {
                // LOG
                return Task.FromResult(new TokenServiceResult() { Message = ex.Message });
            }
        }

        public Task<TokenServiceResult> RefreshTokenAsync(User user, long? expireDate = null)
        {
            throw new NotImplementedException();
        }
    }
}
