using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;
using NetDevPack.Messaging;

namespace Infra.Bus
{
    public class MediatorBus : IMediatorHandler
    {
        private readonly IMediator mediatr;

        public MediatorBus(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public Task PublishEvent<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await mediatr.Send(command);
        }
    }
}