using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class AuthenticationResult : BaseServiceResult
    {
        public bool IsUserAuthenticated { get; set; } = false;
        public User? AuthenticatedUser { get; set; }
        public Exception? Exception { get; set; }
    }
}
