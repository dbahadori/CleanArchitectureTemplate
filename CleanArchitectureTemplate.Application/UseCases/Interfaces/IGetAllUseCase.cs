using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Domain.DTO;

namespace CleanArchitectureTemplate.Application.UseCases.Interfaces
{
    public interface IGetAllUseCase
    {
        Task<OperationResult> ExecuteAsync(GetAllRequestDTO request, CancellationToken cancellationToken);

    }

    public interface IGetAllUseCase<TModel, Key>
    {
        Task<OperationResult> ExecuteAsync(GetAllRequestDTO<Key> request, CancellationToken cancellationToken);

    }
}
