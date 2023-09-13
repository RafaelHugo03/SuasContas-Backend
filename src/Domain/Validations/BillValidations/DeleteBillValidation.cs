using Domain.Commands.BillCommands;

namespace Domain.Validations.BillValidations
{
    public class DeleteBillValidation : BillCommandValidations<DeleteBillCommand>
    {
        public DeleteBillValidation()
        {
            ValidateId();
            ValidateUserId();
        }   
    }
}