using Domain.Commands.BillCommands;
using Domain.Commands.UserCommands;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using FluentValidation.Results;
using Infra.Bus;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Infra.DomainDependencies
{
    public static class DependencyInjector
    {

        public static void InjectDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMediatorHandler, MediatorBus>();
            AddHandlers(serviceCollection);
            AddRepositories(serviceCollection);
        }
        private static void AddHandlers(IServiceCollection serviceCollection)
        {
            // User
            serviceCollection.AddScoped<IRequestHandler<CreateUserCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<EditUserCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<EditEmailCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<EditPasswordCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<SetPremiumUserCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<LoginCommand, ValidationResult>, UserHandler>();

            //Bill
            serviceCollection.AddScoped<IRequestHandler<CreateBillCommand, ValidationResult>, BillHandler>();
            serviceCollection.AddScoped<IRequestHandler<EditBillCommand, ValidationResult>, BillHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteBillCommand, ValidationResult>, BillHandler>();
        }

        private static void AddRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IBillRepository, BillRepository>();
        }
    }
}