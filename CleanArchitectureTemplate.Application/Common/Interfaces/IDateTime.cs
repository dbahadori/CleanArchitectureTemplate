﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Interfaces
{
    public interface IDateTime
    {
        long TimeStampNow { get; }
        DateTime DateTimeNow { get; }

    }
}