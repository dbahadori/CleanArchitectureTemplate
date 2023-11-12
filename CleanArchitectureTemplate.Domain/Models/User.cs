using CleanArchitectureReferenceTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class User
    {
        public User()
        {
            Sessions = new List<Session>();
            Roles = new List<Role>();
        }
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public List<Session> Sessions { get; private set; }
        public List<Role> Roles { get; private set; }
        public UserProfile? UserProfile { get; set; }

        public User AddSessions(Session session)
        {
            this.Sessions.Add(session);
            return this;
        }

        public User UpdateSession(Session session)
        {
            var SessionIndex = this.Sessions.FindIndex(x => x.DeviceHash!.ToUpper() == session.DeviceHash!.ToUpper());
            if (SessionIndex == -1)
                throw new ModelNotFoundException();

            this.Sessions[SessionIndex].LastLoggedindAt = session.LastLoggedindAt;
            return this;
        }

        public User RemoveSessions(Session session)
        {
            this.Sessions.Remove(session);
            return this;
        }


        public bool HasSession(Session session)
        {
            return this.Sessions.Any(x => x.DeviceHash!.ToUpper() == session.DeviceHash!.ToUpper());
        }

        public User AddProfile(UserProfile userProfile)
        {
            userProfile.UserId = this.Id;
            this.UserProfile = userProfile;
            return this;
        }


    }
}
