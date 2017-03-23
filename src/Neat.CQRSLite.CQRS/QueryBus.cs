using System;
using Neat.CQRSLite.Contract.Queries;

namespace Neat.CQRSLite.CQRS
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IQueryPerformer> _queryPerformerResolver;

        public QueryBus(Func<Type, IQueryPerformer> queryPerformerResolver)
        {
            _queryPerformerResolver = queryPerformerResolver;
        }

        public TResult Perform<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryPerformer<,>).MakeGenericType(query.GetType(), typeof(TResult));

            var performer = _queryPerformerResolver(handlerType);
            return (TResult) ((dynamic) performer).Perform((dynamic) query);
        }
    }
}