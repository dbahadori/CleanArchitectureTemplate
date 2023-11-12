using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces;

namespace CleanArchitectureReferenceTemplate.Domain.Entities
{
    public class SessionEntity : AuditableEntity
    {
        public SessionEntity()
        {
            Settings = new List<SettingEntity>();
        }

        /// <summary>
        /// Gets or sets the firebase token.
        /// </summary>
        public string? FireBaseToken { get; set; }

        /// <summary>
        /// Gets or sets the device information of the logined user.
        /// </summary>
        public string? Device { get; set; }

        /// <summary>
        /// Gets or sets the MD5 of device information of the logined user.
        /// </summary>
        public string? DeviceHash { get; set; }

        /// <summary>
        /// Gets or sets the user foreign key.
        /// </summary>

        public long LastLoggedindAt { get; set; }

        public required Guid UserId { get; set; }
        public UserEntity? User { get; set; }


        public virtual IList<SettingEntity> Settings { get; set; }

    }

}