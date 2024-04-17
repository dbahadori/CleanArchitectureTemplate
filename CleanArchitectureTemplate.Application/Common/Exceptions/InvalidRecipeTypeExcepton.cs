using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class InvalidRecipeTypeExcepton: CustomException
    {
        public InvalidRecipeTypeExcepton()
            : base(string.Empty, null)
        {
        }
    }
}
