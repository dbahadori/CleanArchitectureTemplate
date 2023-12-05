using CleanArchitectureTemplate.Domain.ValueObejects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface IFileParserService
    {
        OperationResult Parse(IFormFile file);
    }
}
