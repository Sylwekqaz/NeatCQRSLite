namespace Neat.CQRSLite.Contract.Commands
{
    public interface ICommandBus
    {
        CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}