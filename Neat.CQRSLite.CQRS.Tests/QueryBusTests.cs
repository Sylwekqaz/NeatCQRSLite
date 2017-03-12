using System;
using Neat.CQRSLite.Contract.Commands;
using Neat.CQRSLite.Contract.Queries;
using NSubstitute;
using Xunit;

namespace Neat.CQRSLite.CQRS.Tests
{
    public class QueryBusTests
    {
        [Fact]
        public void HappyPath()
        {
            var query = Substitute.For<IQuery<string>>();
            var queryPerformer = Substitute.For<IQueryPerformer<IQuery<string>, string>>();
            queryPerformer.Perform(query).Returns("Succes");
            var queryBus = new QueryBus(t => queryPerformer);

            var queryResult = queryBus.Perform(query);

            Assert.Equal("Succes", queryResult);
        }


        [Fact]
        public void TypeCheck()
        {
            var query = new TestQuery();
            var queryPerformer = new TestQueryPerformer("Whatever");
            Type requestedType = typeof(void);
            var queryBus = new QueryBus(t =>
            {
                requestedType = t;
                return queryPerformer;
            });

            queryBus.Perform(query);

            Assert.Equal(typeof(IQueryPerformer<TestQuery, string>), requestedType);
        }

        public class TestQuery : IQuery<string>
        {
        }

        public class TestQueryPerformer : IQueryPerformer<TestQuery, string>
        {
            private string _returnValue;

            public TestQueryPerformer(string returnValue)
            {
                _returnValue = returnValue;
            }

            public string Perform(TestQuery query)
            {
                return _returnValue;
            }
        }
    }
}