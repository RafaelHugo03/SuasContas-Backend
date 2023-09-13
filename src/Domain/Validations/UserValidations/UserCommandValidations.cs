using Domain.Commands.UserCommands;
using FluentValidation;

namespace Domain.Validations.UserValidations
{
    public class UserCommandValidations<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateEmail()
        { 
            RuleFor(u => u.EmailAddress)
                .EmailAddress().WithMessage("Insira um e-mail válido");
        }

        protected void ValidateNewPassword()
        { 
            RuleFor(u => u.NewPassword)
                .MinimumLength(8)
                .WithMessage("Senha deve ser maior que 8 caracteres");
        }

        protected void ValidatePassword()
        { 
            RuleFor(u => u.Password)
                .MinimumLength(8)
                .WithMessage("Senha deve ser maior que 8 caracteres");
        }

        protected void ValidateName()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Nome inválido")
                .Length(2, 40).WithMessage("Nome deve conter no mínimo 2 caracteres e no máximo 40");
        }

        protected void ValidateId()
        {
            RuleFor(u => u.Id)
                .NotNull().WithMessage("Id não pode ser nulo");
        }
    }
}