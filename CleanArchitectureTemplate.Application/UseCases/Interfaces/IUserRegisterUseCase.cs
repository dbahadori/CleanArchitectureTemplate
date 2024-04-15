using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Interfaces;
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
