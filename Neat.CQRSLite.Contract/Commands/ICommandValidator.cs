namespace Neat.CQRSLite.Contract.Commands
{
    public interface ICommandValidator<T> where T : ICommand
    {
    }
}