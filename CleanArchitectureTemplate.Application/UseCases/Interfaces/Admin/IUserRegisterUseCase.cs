using CleanArchitectureTemplate.Application.DTO.V1.AdminControlPanel;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces.Admin
{
    public interface IUserRegisterUseCase
    {
        Task<OperationResult> RegisterAsync(UserRegisterRequestDTO input, CancellationToken cancellationToken);

    }
}
