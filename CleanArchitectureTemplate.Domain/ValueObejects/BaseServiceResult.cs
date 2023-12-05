using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.ValueObejects
{
    public class BaseServiceResult
    {
        public bool IsSuccess { get; set; } = false;
        public  Exception? Exception { get; set; }
    }
}
