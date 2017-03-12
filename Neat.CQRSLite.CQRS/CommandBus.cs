using System;
using System.Linq;
using Neat.CQRSLite.Contract.Commands;

namespace Neat.CQRSLite.CQRS
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, ICommandHandler<ICommand>> _commandHandlerResolver;
        private readonly Func<Type, ICommandValidator<ICommand>> _validatorResolver;

        public CommandBus(Func<Type, ICommandValidator<ICommand>> validatorResolver,
            Func<Type, ICommandHandler<ICommand>> commandHandlerResolver)
        {
            _validatorResolver = validatorResolver;
            _commandHandlerResolver = commandHandlerResolver;
        }

        public CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandValidator = _validatorResolver(typeof(TCommand));
            if (commandValidator != null)
            {
                var validationErrors = commandValidator.Validate(command);
                if (validationErrors.Any())
                    return CommandResult.NotValid(validationErrors);
            }
            _commandHandlerResolver(typeof(TCommand)).Execute(command);
            return CommandResult.Success();
        }
    }
}