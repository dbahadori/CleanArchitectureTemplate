using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Common.Services.Utilities;
using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class User : AuditableEntity
    {
        private string? hashedPassword;

        public User()
        {
            Sessions = new List<Session>();
            Roles = new List<Role>();
        }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public List<Session> Sessions { get; private set; }
        public List<Role> Roles { get; private set; }
        public UserProfile? UserProfile { get; set; }

        public void SetHashedPassword(string password)
        {
            hashedPassword = DomainUtilityService.CreateSHA512(password);
        }

        // Validate the provided password against the stored hashed password
        public bool ValidatePassword(string password)
        {
            if (hashedPassword == null)
            {
                throw new InvalidOperationException("Password not set for the user.");
            }

            return DomainUtilityService.CreateSHA512(password) == hashedPassword;
        }
        public User AddSessions(Session session)
        {
            Sessions.Add(session);
            return this;
        }

        public bool UserHasRole(Role targetRole)
        {
            return Roles.Any(role => role.Name.Equals(targetRole.ToString(), StringComparison.OrdinalIgnoreCase));
        }
        public User UpdateSession(Session session)
        {
            var SessionIndex = Sessions.FindIndex(x => x.DeviceHash!.ToUpper() == session.DeviceHash!.ToUpper());
            if (SessionIndex == -1)
                throw new Exception(); // use proper exception 

            Sessions[SessionIndex].LastLoggedindAt = session.LastLoggedindAt;
            return this;
        }

        public User RemoveSessions(Session session)
        {
            Sessions.Remove(session);
            return this;
        }


        public bool HasSession(Session session)
        {
            return Sessions.Any(x => x.DeviceHash!.ToUpper() == session.DeviceHash!.ToUpper());
        }

        public User AddProfile(UserProfile userProfile)
        {
            userProfile.UserId = Id;
            UserProfile = userProfile;
            return this;
        }


    }
}
