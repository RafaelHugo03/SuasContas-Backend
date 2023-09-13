using Application.DTOs;
using Application.Services.Contracts;
using Domain.Commands.UserCommands;
using Domain.Repositories;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediator;

        public UserService(IUserRepository userRepository,
            IMediatorHandler mediator)
        {
            this.userRepository = userRepository;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> ChangeEmail(UserDTO entity)
        {
            var command = new EditEmailCommand(
                entity.Id,
                entity.EmailAddress
            );
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> ChangePassword(UserDTO entity)
        {
            var command = new EditPasswordCommand(
                entity.Id,
                entity.Password,
                entity.NewPassword
            );
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Create(UserDTO entity)
        {
             var command = new CreateUserCommand(
                entity.Name,
                entity.EmailAddress,
                entity.Password,
                entity.ReceiveEmail
            );
            return await mediator.SendCommand(command);
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await userRepository.GetById(id);
            return new UserDTO(user);
        }

        public async Task<UserDTO> GetUserByEmail(string emailAddress)
        {
            var user = await userRepository.GetUserByEmail(emailAddress);
            return new UserDTO(user);
        }

        public async Task<ValidationResult> Login(UserDTO entity)
        {
            var command = new LoginCommand(
                entity.EmailAddress,
                entity.Password
            );
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> SetUserPremium(UserDTO entity)
        {
            var command = new SetPremiumUserCommand(
                entity.Id
            );
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(UserDTO entity)
        {
            var command = new EditUserCommand(
                entity.Id,
                entity.Name,
                entity.ReceiveEmail
            );
            return await mediator.SendCommand(command);
        }
        
        public async Task<ValidationResult> ValidateEmail(UserDTO entity)
        {
            var command = new ValidateEmailCommand(
                entity.Id
            );
            return await mediator.SendCommand(command);
        }
    }
}