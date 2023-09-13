using Domain.Entities;
using Domain.enums;
using Domain.Validations.BillValidations;

namespace Domain.Commands.BillCommands
{
    public class EditBillCommand : BillCommand
    {
        public EditBillCommand(
            Guid id,
            string name,
            decimal price,
            DateTime dueDate,
            int? installments,
            DateTime? lastInstallmentDate,
            Guid userId,
            BillType type
        )
        {
            switch(type)
            {
                case BillType.SingleBill: LastInstallmentDate = null; Installments = null; break;
                case BillType.MonthlyBill: LastInstallmentDate = null; Installments = null; break;
                case BillType.InstallmentBill: LastInstallmentDate = lastInstallmentDate; Installments = installments; break;
            }
            Id = id;
            Name = name;
            Price = price;
            DueDate = dueDate;
            UserId = userId;
            Type = type;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditBillValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public Bill ToEntity()
        {
            return new Bill(
                Id,
                Name,
                Price,
                Type,
                DueDate,
                Installments,
                LastInstallmentDate,
                UserId
            );
        }
    }
}