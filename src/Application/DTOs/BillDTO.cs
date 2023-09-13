using Domain.Entities;
using Domain.enums;
using Infra.Repositories;

namespace Application.DTOs
{
    public class BillDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BillType Type { get; set; }
        public DateTime DueDate { get; set; }
        public int? Installments { get; set; }
        public DateTime? LastInstallmentDate { get; set; }
        public Guid UserId { get; set; }

        public BillDTO()
        {
        }

        public BillDTO(Bill bill)
        {
            Id = bill.Id;
            Name = bill.Name;
            Price = bill.Price;
            Type = bill.Type;
            DueDate = bill.DueDate;
            Installments = bill.Installments;
            LastInstallmentDate = bill.LastInstallmentDate;
            UserId = bill.UserId;
        }

        public static List<BillDTO> ToEnumerable(List<Bill> bills)
        {
            return bills.Select(b => new BillDTO(b)).ToList();
        }
    }
}