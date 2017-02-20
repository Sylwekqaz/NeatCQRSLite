using System;

namespace Neat.CQRSLite.Contract.Events
{
    public interface IEvent : IEvent<Guid>
    {
    }

    public interface IEvent<out TKey>
    {
        TKey EventId { get; }
    }
}