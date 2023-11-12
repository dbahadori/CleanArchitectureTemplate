using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Domain.ValueObejects
{
    public class BaseServiceResult
    {
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
    }
}
