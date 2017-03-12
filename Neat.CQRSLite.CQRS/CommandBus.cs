using System;
using System.Collections.Generic;
using System.Linq;
using Neat.CQRSLite.Contract.Commands;

namespace Neat.CQRSLite.CQRS
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, ICommandHandler> _commandHandlerResolver;
        private readonly Func<Type, ICommandValidator> _validatorResolver;

        public CommandBus(Func<Type, ICommandValidator> validatorResolver,
            Func<Type, ICommandHandler> commandHandlerResolver)
        {
            _validatorResolver = validatorResolver;
            _commandHandlerResolver = commandHandlerResolver;
        }

        public CommandResult Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandValidator = _validatorResolver(typeof(ICommandValidator<TCommand>));
            if (commandValidator != null)
            {
                var validationErrors =
                    (IEnumerable<ValidationError>) ((dynamic) commandValidator).Validate((dynamic) command);
                if (validationErrors.Any())
                    return CommandResult.NotValid(validationErrors);
            }
            var commandHandler = _commandHandlerResolver(typeof(ICommandHandler<TCommand>));
            ((dynamic) commandHandler).Execute((dynamic) command);
            return CommandResult.Success();
        }
    }
}