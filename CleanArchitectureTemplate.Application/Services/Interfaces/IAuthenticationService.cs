using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateUserAsync(string username, string password);
    }
}
