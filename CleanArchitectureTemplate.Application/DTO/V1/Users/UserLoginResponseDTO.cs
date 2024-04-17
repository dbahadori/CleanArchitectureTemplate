using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.DTO.V1.Users
{
    public class UserLoginResponseDTO
    {
        public required string Token { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
