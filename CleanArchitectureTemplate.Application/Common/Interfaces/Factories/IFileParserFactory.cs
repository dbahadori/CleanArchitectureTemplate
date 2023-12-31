﻿using CleanArchitectureTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Interfaces.Factories
{
    public interface IFileParserFactory
    {
        public IHttpFileParser GetParserForHttpRequestFile(FileExtension extension);
    }
}
