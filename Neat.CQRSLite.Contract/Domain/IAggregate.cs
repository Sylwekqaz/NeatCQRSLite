using System;

namespace Neat.CQRSLite.Contract.Domain
{
    public interface IAggregate<out TKey>
    {
        TKey Id { get; }
    }

    public interface IAggregate : IAggregate<Guid>
    {
    }
}