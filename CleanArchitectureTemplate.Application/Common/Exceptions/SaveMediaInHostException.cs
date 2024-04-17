﻿using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class SaveMediaInHostException : CustomException
    {

        public SaveMediaInHostException()
            : base(string.Empty, null)
        {
        }


    }
}
