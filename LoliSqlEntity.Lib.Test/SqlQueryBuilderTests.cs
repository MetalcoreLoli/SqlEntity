using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class SqlQueryBuilderTests
    {
        [Test]
        public void ConstructTest()
        {
            var mockContainer = new MockRuleContainer().AddRule<MockQuery>(new MockRule());            
            var sqlQueryAsString = 
                new SqlQueryBuilder<MockQuery>(mockContainer)
                    .Construct(); 
            Assert.AreEqual("MOCKQUERY;\ngo\n", sqlQueryAsString);
        }

        [Test]
        public void AddParameterTest()
        {
            var mockContainer = new MockRuleContainer().AddRule<MockQuery>(new MockRule());            
            var sqlQueryAsString =
                new SqlQueryBuilder<MockQuery>(mockContainer)
                    .AddParameter(new MockParameter("value", new MockType()))
                    .Construct();
            
            Assert.AreEqual("MOCKQUERY MOCKPARAM = 'value';\ngo\n", sqlQueryAsString);
        }
    }
}