using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.DTO.V1
{
    public class UserLoginOutputMessage
    {
        public required string Token { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}
