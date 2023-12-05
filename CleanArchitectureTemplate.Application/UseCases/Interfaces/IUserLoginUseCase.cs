using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces
{
    public interface IUserLoginUseCase
    {
        Task<OperationResult> LoginAsync(UserLoginInputModel input);

    }
}
