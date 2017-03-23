namespace Neat.CQRSLite.Contract.Queries
{
    public interface IQueryBus
    {
        TResult Perform<TResult>(IQuery<TResult> query);
    }
}