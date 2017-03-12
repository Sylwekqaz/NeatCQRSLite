using System;
using Neat.CQRSLite.Contract.Events;
using NSubstitute;
using Xunit;

namespace Neat.CQRSLite.CQRS.Tests
{
    public class EventBusTests
    {
        [Fact]
        public void HappyPath()
        {
            var @event = Substitute.For<IEvent>();
            var eventHandler = Substitute.For<IEventHandler<IEvent>>();
            var eventBus = new EventBus(t => new[] {eventHandler});

            eventBus.Send(@event);

            eventHandler.Received(1).Handle(@event);
        }


        [Fact]
        public void TypeCheck()
        {
            var @event = new TestEvent();
            var eventHandler = new TestEventHandler();
            Type requestedType = typeof(void);
            var eventBus = new EventBus(t =>
            {
                requestedType = t;
                return new[] {eventHandler};
            });

            eventBus.Send(@event);

            Assert.Equal(typeof(IEventHandler<TestEvent>), requestedType);
        }

        public class TestEvent : IEvent
        {
        }

        public class TestEventHandler : IEventHandler<TestEvent>
        {
            public void Handle(TestEvent @event)
            {
                //do nothing
            }
        }
    }
}