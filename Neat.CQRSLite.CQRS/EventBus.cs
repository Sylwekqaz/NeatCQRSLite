using System;
using System.Collections.Generic;
using Neat.CQRSLite.Contract.Events;

namespace Neat.CQRSLite.CQRS
{
    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IEventHandler>> _eventHandlersResolver;

        public EventBus(Func<Type, IEnumerable<IEventHandler>> eventHandlersResolver)
        {
            _eventHandlersResolver = eventHandlersResolver;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _eventHandlersResolver(typeof(IEventHandler<TEvent>));
            foreach (var eventHandler in handlers)
            {
                ((dynamic) eventHandler).Handle((dynamic) @event);
            }
        }
    }
}