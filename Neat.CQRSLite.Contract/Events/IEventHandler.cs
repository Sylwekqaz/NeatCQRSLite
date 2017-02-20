namespace Neat.CQRSLite.Contract.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public interface IEventHandler<in TEvent, TEventKey> where TEvent : IEvent<TEventKey>
    {
        void Handle(TEvent @event);
    }
}