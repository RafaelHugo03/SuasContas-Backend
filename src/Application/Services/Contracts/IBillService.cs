
using Application.DTOs;
using FluentValidation.Results;

namespace Application.Services.Contracts
{
    public interface IBillService
    {
        Task<ValidationResult> Create(BillDTO entity);
        Task<ValidationResult> Update(BillDTO entity, Guid userId);
        Task<ValidationResult> Delete(Guid id, Guid userId);
        Task<List<BillDTO>> GetUserBills(Guid userId);
    }
}