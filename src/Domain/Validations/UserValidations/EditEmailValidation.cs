using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class EditEmailValidation : UserCommandValidations<EditEmailCommand>
    {
        public EditEmailValidation()
        {
            ValidateId();
            ValidateEmail();
        }
    }
}