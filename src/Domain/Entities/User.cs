using Domain.enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User(Guid id, 
            string name,
            string emailAddress,
            string password,
            bool receiveEmail)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            ReceiveEmail = receiveEmail;
        }

        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        public bool ReceiveEmail { get; private set; }
        public bool IsValidEmail { get; private set; } = false;
        public bool IsPremiumUser { get; private set; } = false;
        public Role Role { get; private set; } = Role.Basic;
        public List<Bill> Bills { get; private set; } = new();

        public void ValidEmail() => IsValidEmail = true;
        public void InvalidEmail() => IsValidEmail = false;

        public void EditEmail(string email) => EmailAddress = email;
        public void EditPassword(string password) => Password = password;
        public void SetUserToPremium()
        {
            IsPremiumUser = true;
            Role = Role.Premium;
        }

        public void UpdateUser(string name,
            bool receiveEmail)
        {
            Name = name;
            ReceiveEmail = receiveEmail;
        }
    }
}