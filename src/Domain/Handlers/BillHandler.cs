using Domain.Commands.BillCommands;
using Domain.Repositories;
using Domain.Utils;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace Domain.Handlers
{
    public class BillHandler : CommandHandler,
        IRequestHandler<CreateBillCommand, ValidationResult>,
        IRequestHandler<EditBillCommand, ValidationResult>,
        IRequestHandler<DeleteBillCommand, ValidationResult>
    {
        private readonly IBillRepository billRepository;

        public BillHandler(IBillRepository billRepository)
        {
            this.billRepository = billRepository;
        }

        public async Task<ValidationResult> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var bill = request.ToEntity();

            billRepository.Create(bill);

            return await Commit(billRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditBillCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var bill = await billRepository.GetById(request.Id);

            var newBill = request.ToEntity();

            if(bill.UserId != newBill.UserId)
            {
                request.ValidationResult.AddError("Não é o usuário responsável pela conta");
                return request.ValidationResult;
            }

            if(bill.Type != newBill.Type)
            {
                request.ValidationResult.AddError("não é possível alterar o tipo da conta");
                return request.ValidationResult;
            }

            bill.UpdateBill(newBill);
            billRepository.Update(bill);

            return await Commit(billRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var bill = await billRepository.GetById(request.Id);

            if(bill.UserId != request.UserId)
            {
                request.ValidationResult.AddError("Não é o dono da conta");
                return request.ValidationResult;
            }

            billRepository.Delete(bill);

            return await Commit(billRepository.UnitOfWork);
        }
    }
}