using System;
using NUnit.Framework;
using LoliSqlEntity.Lib.Guards;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib.Test.Guards
{
    public class QueryTypeGuardTests
    {

        [Test]
        public void QueryTypeGuardsTest()
        {
            var queryGuard = new QueryTypeGuard(DefaultRuleContainer.Instance);
            
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                queryGuard.Execute(new TypeGuardArg(typeof(MockQuery))));
        }
    }
}