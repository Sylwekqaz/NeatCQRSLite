using System.Collections.Generic;

namespace Neat.CQRSLite.Contract.Commands
{
    public interface ICommandValidator
    {
    }

    public interface ICommandValidator<in T> : ICommandValidator where T : ICommand
    {
        IEnumerable<ValidationError> Validate(T command);
    }
}