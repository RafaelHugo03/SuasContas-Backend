
using Application.DTOs;
using Application.Services.Contracts;
using Domain.Commands.BillCommands;
using Domain.Repositories;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace Application.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billRepository;
        private readonly IMediatorHandler mediator;

        public BillService(IBillRepository billRepository,
            IMediatorHandler mediator)
        {
            this.billRepository = billRepository;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> Create(BillDTO entity)
        {
            var command = new CreateBillCommand(
                entity.Name,
                entity.Price,
                entity.Type,
                entity.DueDate,
                entity.UserId,
                entity.Installments,
                entity.LastInstallmentDate
            );
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Delete(Guid id, Guid userId)
        {
            var command = new DeleteBillCommand(
                id,
                userId
            );
            return await mediator.SendCommand(command);
        }

        public async Task<List<BillDTO>> GetUserBills(Guid userId)
        {
            var bills = await billRepository.GetBillsByUser(userId);
            return BillDTO.ToEnumerable(bills);
        }

        public async Task<ValidationResult> Update(BillDTO entity, Guid userId)
        {
            var command = new EditBillCommand(
                entity.Id,
                entity.Name,
                entity.Price, 
                entity.DueDate,
                entity.Installments,
                entity.LastInstallmentDate,
                userId,
                entity.Type
            );
            return await mediator.SendCommand(command);
        }
    }
}