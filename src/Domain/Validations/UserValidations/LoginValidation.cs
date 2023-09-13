using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class LoginValidation : UserCommandValidations<LoginCommand>
    {
        public LoginValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}