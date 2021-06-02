using System;
using LoliSqlEntity.Lib.Rules;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class RuleContainerTests
    {

        [Test]
        public void MockRuleContainerAddTest()
        {
            var container = new MockRuleContainer();
            var rule = container.AddRule<MockQuery>(new MockRule()).GetRule<MockQuery>();
           
            Assert.That(rule.GetType() == typeof(MockRule), Is.True);
        }
        
        [Test]
        public void MockRuleContainerRemoveTest()
        {
            var container = new MockRuleContainer();
            var rule = container.AddRule<MockQuery>(new MockRule());
            container.RemoveRule<MockQuery>();
           
            Assert.Throws<ArgumentOutOfRangeException>(() => container.GetRule<MockQuery>());
        }


        [Test]
        public void DefaultRuleContainerRemoveTest()
        {
            var container = new DefaultRuleContainer();

            Assert.Throws<ArgumentOutOfRangeException>(() => 
                container.AddRule<MockQuery>(new MockRule()).RemoveRule<MockQuery>().GetRule<MockQuery>());
        }
    }
    
}