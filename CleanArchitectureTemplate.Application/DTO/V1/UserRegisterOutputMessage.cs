using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.DTO.V1
{
    public class UserRegisterOutputMessage
    {
        public required string Id { get; set; }
        public string? FullName { get; set; }
        public required string Email { get; set; }
    }
}
