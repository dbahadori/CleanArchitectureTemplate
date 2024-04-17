using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Enums
{
    public enum ErrorCodes
    {
        NO_ERROR,
        [Display(Name = "auth-001")]
        AUTHENTICATION,

        [Display(Name = "validation")]
        VALIDATION

    }
}
