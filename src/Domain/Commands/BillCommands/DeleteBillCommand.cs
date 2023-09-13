using Domain.Validations.BillValidations;

namespace Domain.Commands.BillCommands
{
    public class DeleteBillCommand : BillCommand
    {
        public DeleteBillCommand(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteBillValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}