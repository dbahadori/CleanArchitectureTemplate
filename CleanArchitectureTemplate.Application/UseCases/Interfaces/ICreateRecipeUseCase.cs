using CleanArchitectureTemplate.Domain.ValueObejects;
using CleanArchitectureTemplate.Application.DTO.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces
{
    public interface ICreateRecipeUseCase
    {
        Task<OperationResult> ExecuteAsync(CreateRecipeInputModel inputMessage);

    }
}
