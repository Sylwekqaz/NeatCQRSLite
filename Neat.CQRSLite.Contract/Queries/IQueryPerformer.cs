namespace Neat.CQRSLite.Contract.Queries
{
    public interface IQueryPerformer<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Perform(TQuery query);
    }
}