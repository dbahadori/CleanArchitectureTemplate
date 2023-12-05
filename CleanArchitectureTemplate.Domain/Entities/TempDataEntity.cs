using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
namespace CleanArchitectureTemplate.Domain.Entities
{
    public class TempDataEntity : AuditableEntity
    {
        public string? VerificationCode { get; set; }
        public int SendCount { get; set; }
        public long LastSendDateAt { get; set; }
        public int FailedCount{ get; set; }
        public bool IsVerified { get; set; }

        public required Guid UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
