namespace Neat.CQRSLite.Contract.Queries
{
    public interface IQueryPerformer
    {
    }

    public interface IQueryPerformer<in TQuery, out TResult> : IQueryPerformer where TQuery : IQuery<TResult>
    {
        TResult Perform(TQuery query);
    }
}