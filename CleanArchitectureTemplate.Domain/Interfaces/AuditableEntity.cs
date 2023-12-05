using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Interfaces
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; } 
        public long CreatedAt { get; set; }
        public long LastModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }

        
    }
}
