﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class TokenServiceResult : BaseServiceResult
    {
        public string? Token { get; set; }
    }
}
