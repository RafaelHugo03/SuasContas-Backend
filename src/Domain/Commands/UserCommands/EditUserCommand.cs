using Domain.Entities;
using Domain.Validations.UserValidations;

namespace Domain.Commands.UserCommands
{
    public class EditUserCommand : UserCommand
    {
        public EditUserCommand(Guid id,
            string name,
            bool receiveEmail)
        {
            Id = id;
            Name = name;
            ReceiveEmail = receiveEmail;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}