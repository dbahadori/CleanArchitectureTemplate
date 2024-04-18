using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenServiceResult> GenerateTokenAsync(IEnumerable<Claim> claims, long? expireDate = null);
        Task<TokenServiceResult> RefreshTokenAsync(User user, long? expireDate = null);

    }
}
