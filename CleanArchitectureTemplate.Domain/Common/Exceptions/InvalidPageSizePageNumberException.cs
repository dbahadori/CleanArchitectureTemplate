using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
    public class InvalidPageSizePageNumberException : CustomException
    {


        public InvalidPageSizePageNumberException()
            : base(string.Empty, null)
        {
        }

        

    }
}
