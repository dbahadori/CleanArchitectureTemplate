using CleanArchitectureTemplate.Application.DTO.V1.Users;
using CleanArchitectureTemplate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces.Users
{
    public interface IUserLoginUseCase
    {
        Task<OperationResult> LoginAsync(UserLoginRequestDTO input);

    }
}
