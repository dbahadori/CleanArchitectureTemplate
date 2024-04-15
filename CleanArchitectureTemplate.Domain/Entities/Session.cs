using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Session : AuditableEntity
    {
        public Session()
        {
            Settings = new List<Setting>();
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

        public IList<Setting> Settings { get; set; }

    }

}