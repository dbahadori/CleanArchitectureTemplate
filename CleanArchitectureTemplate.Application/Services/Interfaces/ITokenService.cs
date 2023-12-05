using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenServiceResult> GenerateTokenAsync(User user, long? expireDate = null);
        Task<TokenServiceResult> RefreshTokenAsync(User user, long? expireDate = null);

    }
}
