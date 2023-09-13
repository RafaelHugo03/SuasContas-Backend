using NetDevPack.Messaging;

namespace Domain.Commands.UserCommands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string EmailAddress { get; protected set; }
        public string Password { get; protected set; }
        public string NewPassword { get; protected set; }
        public bool ReceiveEmail { get; protected set; }
        public string? ImageUrl { get; protected set; }
    }
}