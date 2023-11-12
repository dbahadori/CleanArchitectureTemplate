using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.DTO.V1
{
    public class UserLoginInputMessage
    {
        public required string Email { get; set; }
        public string? Password { get; set; }
        public required string Device { get; set; }
        public required string DeviceHash { get; set; }
        public string? FireBaseToken { get; set; }
    }
}
