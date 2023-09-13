using Domain.Commands.BillCommands;
using Domain.enums;
using FluentValidation;

namespace Domain.Validations.BillValidations
{
    public class BillCommandValidations<T> : AbstractValidator<T> where T : BillCommand
    {
        protected void ValidateName()
        { 
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Nome inválido");
        }
        protected void ValidateUserId()
        { 
            RuleFor(u => u.UserId)
                .NotNull().WithMessage("Id do usuário inválido");
        }

        protected void ValidateId()
        { 
            RuleFor(u => u.Id)
                .NotNull().WithMessage("Id inválido");
        }

        protected void ValidatePrice()
        { 
            RuleFor(u => u.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Preço inválido");
        }

        protected void ValidateDueDate()
        {
            RuleFor(u => u.DueDate)
                .NotNull();
        }

        protected void ValidateInstallments()
        {
            RuleFor(u => u.Installments)
                .GreaterThan(0)
                .WithMessage("Necessário informar parcelas");
        }

        protected void ValidateLastInstallmentDate()
        {
            RuleFor(u => u.LastInstallmentDate)
                .NotNull();
        }
    }
}