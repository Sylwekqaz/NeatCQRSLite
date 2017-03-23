using System;

namespace Neat.CQRSLite.Contract.Events
{
    public interface IEventHandler
    {
    }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }
}