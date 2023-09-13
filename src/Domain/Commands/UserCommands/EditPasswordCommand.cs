using Domain.Validations.UserValidations;

namespace Domain.Commands.UserCommands
{
    public class EditPasswordCommand : UserCommand
    {
        public EditPasswordCommand(
            Guid id,
            string password,
            string newPassword
        )
        {
            Id = id;
            Password = password;
            NewPassword = newPassword;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditPasswordValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}