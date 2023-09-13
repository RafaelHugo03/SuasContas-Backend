using Domain.Commands.BillCommands;
using Domain.enums;

namespace Domain.Validations.BillValidations
{
    public class EditBillValidation : BillCommandValidations<EditBillCommand>
    {
        public EditBillValidation(EditBillCommand command)
        {
             switch(command.Type)
            {
                case BillType.SingleBill: 
                    ValidateId();
                    ValidateDueDate();
                    ValidateUserId();
                    ValidateName();
                    ValidatePrice();
                    break;
                case BillType.MonthlyBill: 
                    ValidateId();
                    ValidateDueDate();
                    ValidateUserId();
                    ValidateName();
                    ValidatePrice();
                    break;
                case BillType.InstallmentBill: 
                    ValidateId();
                    ValidateDueDate();
                    ValidateUserId();
                    ValidateName();
                    ValidatePrice();
                    ValidateInstallments();
                    ValidateLastInstallmentDate();
                    break;
            }
        }
    }
}