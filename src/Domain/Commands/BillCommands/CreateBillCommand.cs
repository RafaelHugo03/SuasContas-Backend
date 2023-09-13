using Domain.Entities;
using Domain.enums;
using Domain.Validations.BillValidations;

namespace Domain.Commands.BillCommands
{
    public class CreateBillCommand : BillCommand
    {
        public CreateBillCommand(
            string name,
            decimal price,
            BillType type,
            DateTime dueDate,
            Guid userId,
            int? installments,
            DateTime? lastInstallmentDate
        )
        {
            switch(type)
            {
                case BillType.SingleBill: LastInstallmentDate = null; Installments = null; break;
                case BillType.MonthlyBill: LastInstallmentDate = null; Installments = null; break;
                case BillType.InstallmentBill: LastInstallmentDate = lastInstallmentDate; Installments = installments; break;
            }
            Name = name;
            Price = price;
            DueDate = dueDate;
            UserId = userId;
            Type = type;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBillValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public Bill ToEntity()
        {
            return new Bill(
                Guid.NewGuid(),
                this.Name,
                this.Price,
                this.Type,
                this.DueDate,
                this.Installments,
                this.LastInstallmentDate,
                this.UserId
            );
        }
    }
}