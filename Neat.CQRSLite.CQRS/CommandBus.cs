using System;
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
                    ((ICommandValidator<TCommand>) commandValidator).Validate(command);
                if (validationErrors.Any())
                    return CommandResult.NotValid(validationErrors);
            }
            var commandHandler = _commandHandlerResolver(typeof(ICommandHandler<TCommand>));
            ((ICommandHandler<TCommand>) commandHandler).Execute(command);
            return CommandResult.Success();
        }
    }
}