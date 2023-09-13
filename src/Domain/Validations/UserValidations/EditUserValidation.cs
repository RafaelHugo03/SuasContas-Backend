using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class EditUserValidation : UserCommandValidations<EditUserCommand>
    {
        public EditUserValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}