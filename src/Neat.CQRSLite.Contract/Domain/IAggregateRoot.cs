using System;

namespace Neat.CQRSLite.Contract.Domain
{
    public interface IAggregateRoot<out TKey>
    {
        TKey Id { get; }
    }

    public interface IAggregateRoot : IAggregateRoot<Guid>
    {
    }
}