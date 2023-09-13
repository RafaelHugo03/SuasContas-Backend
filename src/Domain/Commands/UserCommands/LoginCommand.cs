using Domain.Validations.UserValidations;

namespace Domain.Commands.UserCommands
{
    public class LoginCommand : UserCommand
    {
        public LoginCommand(
            string emailAddress,
            string password
        )
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new LoginValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}