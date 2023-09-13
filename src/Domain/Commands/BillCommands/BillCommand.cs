using Domain.enums;
using NetDevPack.Messaging;

namespace Domain.Commands.BillCommands
{
    public class BillCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public BillType Type { get; protected set; }
        public DateTime DueDate { get; protected set; }
        public int? Installments { get; protected set; }
        public DateTime? LastInstallmentDate { get; protected set; }
        public Guid UserId { get; protected set; }
    }
}