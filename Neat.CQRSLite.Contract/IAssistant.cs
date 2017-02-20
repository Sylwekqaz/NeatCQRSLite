using Neat.CQRSLite.Contract.Commands;
using Neat.CQRSLite.Contract.Events;
using Neat.CQRSLite.Contract.Queries;

namespace Neat.CQRSLite.Contract
{
    public interface IAssistant
    {
        CommandResult Do<TCommand>(TCommand command) where TCommand : ICommand;
        void Tell<TEvent, TKey>(TEvent @event) where TEvent : IEvent<TKey>;
        TResult Give<TResult, TQuery>(TQuery query) where TQuery:IQuery<TResult>;
        bool Check<TQuery>(TQuery query) where TQuery : IQuery<bool>;
    }
}