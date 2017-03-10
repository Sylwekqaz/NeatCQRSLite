using System.Collections.Generic;

namespace Neat.CQRSLite.Contract.Commands
{
    public interface ICommandValidator<in T> where T : ICommand
    {
        IEnumerable<ValidationError> Validate(T command);
    }
}