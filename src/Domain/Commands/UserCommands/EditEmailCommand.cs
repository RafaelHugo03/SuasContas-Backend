using Domain.Validations.UserValidations;

namespace Domain.Commands.UserCommands
{
    public class EditEmailCommand : UserCommand
    {
        public EditEmailCommand(
            Guid id,
            string emailAddress
        )
        {
            Id = id;
            EmailAddress = emailAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditEmailValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}