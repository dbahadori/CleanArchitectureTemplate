using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.ValueObejects;
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
