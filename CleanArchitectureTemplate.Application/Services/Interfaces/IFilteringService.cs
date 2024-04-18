using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface IFilteringService
    {
        bool ApplyFilteringCriteria<TModel>(TModel model, Dictionary<string, string> filters);

    }
}
