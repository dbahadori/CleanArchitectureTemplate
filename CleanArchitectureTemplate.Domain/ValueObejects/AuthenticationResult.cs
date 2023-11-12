using CleanArchitectureReferenceTemplate.Domain.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Domain.ValueObejects
{
    public class AuthenticationResult : BaseServiceResult
    {
        public bool IsUserAuthenticated { get; set; } = false;
        public User? AuthenticatedUser { get; set; }
        public Exception? Exception { get; set; }
    }
}
