using Application.DTOs;
using FluentValidation.Results;

namespace Application.Services.Contracts
{
    public interface IUserService
    {
        Task<ValidationResult> Create(UserDTO entity);
        Task<ValidationResult> Login(UserDTO entity);
        Task<ValidationResult> Update(UserDTO entity);
        Task<ValidationResult> ChangePassword(UserDTO entity);
        Task<ValidationResult> ChangeEmail(UserDTO entity);
        Task<ValidationResult> SetUserPremium(UserDTO entity);
        Task<ValidationResult> ValidateEmail(UserDTO entity);
        Task<UserDTO> GetUser(Guid id);
        Task<UserDTO> GetUserByEmail(string emailAddress);
    }
}