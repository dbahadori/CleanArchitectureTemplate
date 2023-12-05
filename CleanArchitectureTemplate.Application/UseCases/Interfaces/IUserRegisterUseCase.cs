using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Domain.ValueObejects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces
{
    public interface IUserRegisterUseCase
    {
        Task<OperationResult> RegisterAsync(UserRegisterInputModel input);

    }
}
