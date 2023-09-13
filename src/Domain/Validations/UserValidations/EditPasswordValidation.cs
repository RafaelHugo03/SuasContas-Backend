using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class EditPasswordValidation : UserCommandValidations<EditPasswordCommand>
    {
        public EditPasswordValidation()
        {
            ValidateId();
            ValidatePassword();
            ValidateNewPassword();
        }
    }
}