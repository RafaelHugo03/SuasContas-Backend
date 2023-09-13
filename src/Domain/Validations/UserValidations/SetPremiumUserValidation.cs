using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class SetPremiumUserValidation : UserCommandValidations<SetPremiumUserCommand>
    {
        public SetPremiumUserValidation()
        {
            ValidateId();
        }
    }
}