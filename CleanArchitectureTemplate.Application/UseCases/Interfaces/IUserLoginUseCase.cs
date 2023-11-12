using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces
{
    public interface IUserLoginUseCase
    {
        Task<OperationResult> LoginAsync(UserLoginInputMessage input);

    }
}
