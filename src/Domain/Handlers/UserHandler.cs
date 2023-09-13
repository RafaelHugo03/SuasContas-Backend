using Domain.Commands.UserCommands;
using Domain.Repositories;
using Domain.Utils;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using SecureIdentity.Password;

namespace Domain.Handlers
{
    public class UserHandler : CommandHandler,
        IRequestHandler<CreateUserCommand, ValidationResult>,
        IRequestHandler<SetPremiumUserCommand, ValidationResult>,
        IRequestHandler<EditUserCommand, ValidationResult>,
        IRequestHandler<EditPasswordCommand, ValidationResult>,
        IRequestHandler<EditEmailCommand, ValidationResult>,
        IRequestHandler<LoginCommand, ValidationResult>
    {
        private readonly IUserRepository userRepository;
        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            if(await userRepository.GetUserByEmail(request.EmailAddress) != null)
            {
                request.ValidationResult.AddError("Já existe um usuário com esse e-mail");
                return request.ValidationResult;
            }

            var user = request.ToEntity();
            userRepository.Create(user);
            
            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(SetPremiumUserCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var user = await userRepository.GetById(request.Id);
            user.SetUserToPremium();
            userRepository.Update(user);

            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var user = await userRepository.GetById(request.Id);
            user.UpdateUser(
                request.Name,
                request.ReceiveEmail
            );
            userRepository.Update(user);
            
            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditPasswordCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var user = await userRepository.GetById(request.Id);

            var isCorrectPassword = PasswordHasher.Verify(user.Password, request.Password);
            if(!isCorrectPassword)
            {
                request.ValidationResult.AddError("Senha atual inválida");
                return request.ValidationResult;
            }

            var password = PasswordHasher.Hash(request.NewPassword);
            user.EditPassword(request.NewPassword);

            userRepository.Update(user);

            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditEmailCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var user = await userRepository.GetById(request.Id);
            var userByEmail = await userRepository.GetUserByEmail(request.EmailAddress);

            if(userByEmail != null && userByEmail.Id != user.Id)
            {
                request.ValidationResult.AddError("Já existe um usuário com esse e-mail");
            }
            
            user.EditEmail(request.EmailAddress);
            user.InvalidEmail();
            userRepository.Update(user);

            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var user = await userRepository.GetUserByEmail(request.EmailAddress);

            if(user == null)
            {
                request.ValidationResult.AddError("E-mail inválido");
            }
            else
            {

                var correctPassword = PasswordHasher.Verify(user.Password, request.Password);

                if(!correctPassword)
                {
                    request.ValidationResult.AddError("Senha incorreta");
                }
            }

            return request.ValidationResult;
        }
    }
}