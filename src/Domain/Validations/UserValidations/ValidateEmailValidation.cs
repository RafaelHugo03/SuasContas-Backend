using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class ValidateEmailValidation : UserCommandValidations<ValidateEmailCommand>
    {
        public ValidateEmailValidation()
        {
            ValidateId();
        }
    }
}