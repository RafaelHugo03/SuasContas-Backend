using Domain.Validations.UserValidations;

namespace Domain.Commands.UserCommands
{
    public class ValidateEmailCommand : UserCommand
    {
        public ValidateEmailCommand(
            Guid id
        )
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new ValidateEmailValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}