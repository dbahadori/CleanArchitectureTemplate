using CleanArchitectureTemplate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Application.DTO.V1;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces
{
    public interface IDeleteUseCase
    {
        Task<OperationResult> ExecuteAsync(CommandRequestDTO request, CancellationToken cancellationToken);

    }
}
