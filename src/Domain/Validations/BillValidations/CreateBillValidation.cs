using Domain.Commands.BillCommands;
using Domain.enums;

namespace Domain.Validations.BillValidations
{
    public class CreateBillValidation : BillCommandValidations<CreateBillCommand>
    {
        public CreateBillValidation(CreateBillCommand command)
        {
            switch(command.Type)
            {
                case BillType.SingleBill: 
                    ValidateDueDate();
                    ValidateUserId();
                    ValidateName();
                    ValidatePrice();
                    break;
                case BillType.MonthlyBill: 
                    ValidateDueDate();
                    ValidateUserId();
                    ValidateName();
                    ValidatePrice();
                    break;
                case BillType.InstallmentBill: 
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