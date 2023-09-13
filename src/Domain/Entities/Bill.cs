using Domain.enums;
using NetDevPack.Domain;

namespace Domain.Entities
{
    public class Bill : BaseEntity
    {
        public Bill(Guid id,
            string name,
            decimal price,
            BillType type,
            DateTime dueDate,
            int? installments,
            DateTime? lastInstallmentDate,
            Guid userId)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
            DueDate = dueDate;
            Installments = installments;
            LastInstallmentDate = lastInstallmentDate;
            UserId = userId;
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public BillType Type { get; private set; }
        public DateTime DueDate { get; private set; }
        public int? Installments { get; private set; }
        public DateTime? LastInstallmentDate { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public void UpdateBill(Bill bill)
        {
            Name = bill.Name;
            Price = bill.Price;
            DueDate = bill.DueDate;
            Installments = bill.Installments;
            LastInstallmentDate = bill.LastInstallmentDate;
        }
    }
}