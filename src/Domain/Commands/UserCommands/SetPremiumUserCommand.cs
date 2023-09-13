namespace Domain.Commands.UserCommands
{
    public class SetPremiumUserCommand : UserCommand
    {
        public SetPremiumUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }
    }
}