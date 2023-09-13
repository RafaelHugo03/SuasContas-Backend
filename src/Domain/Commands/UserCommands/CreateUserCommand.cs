using Domain.Entities;
using Domain.Validations.UserValidations;
using SecureIdentity.Password;

namespace Domain.Commands.UserCommands
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(string name,
            string emailAddress,
            string password,
            bool receiveEmail)
        {
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            ReceiveEmail = receiveEmail;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        
        public User ToEntity()
        {
            return new User(
                Guid.NewGuid(),
                this.Name,
                this.EmailAddress,
                PasswordHasher.Hash(this.Password),
                this.ReceiveEmail
            );
        }
    }
}