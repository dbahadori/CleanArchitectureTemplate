using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Validations
{
    public interface IModelValidator
    {
        public bool Validate<T>(T model);
        public void ValidateAndThrow<T>(T model);
    }
}
