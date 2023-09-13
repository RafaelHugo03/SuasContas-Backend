using Domain.Commands.UserCommands;

namespace Domain.Validations.UserValidations
{
    public class CreateUserValidation : UserCommandValidations<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            ValidateName();
            ValidatePassword();
            ValidateEmail();
        }
    }
}