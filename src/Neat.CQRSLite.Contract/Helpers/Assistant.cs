using Neat.CQRSLite.Contract.Commands;
using Neat.CQRSLite.Contract.Events;
using Neat.CQRSLite.Contract.Queries;

namespace Neat.CQRSLite.Contract.Helpers
{
    public class Assistant
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public Assistant(IEventBus eventBus, ICommandBus commandBus, IQueryBus queryBus)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public CommandResult Do<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _commandBus.Execute(command);
        }

        public void Tell<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _eventBus.Send(@event);
        }

        public TResult Give<TResult>(IQuery<TResult> query)
        {
            return _queryBus.Perform(query);
        }

        public bool Check<TQuery>(TQuery query) where TQuery : IQuery<bool>
        {
            return _queryBus.Perform(query);
        }
    }
}