using CleanArchitectureReferenceTemplate.Domain.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateUserAsync(string username, string password);
    }
}
