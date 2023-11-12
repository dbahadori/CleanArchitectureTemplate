using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Services.Interfaces
{
    public interface IFileParserService
    {
        OperationResult Parse(IFormFile file);
    }
}
