namespace Neat.CQRSLite.Contract.Events
{
    public interface IEventBus
    {
        void Send<T>(T @event) where T : IEvent;
    }
}