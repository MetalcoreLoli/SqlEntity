using System;
using System.Collections.Generic;
using LoliSqlEntity.Lib.Table;

namespace LoliSqlEntity.Lib.Rules
{
    public class DefaultRuleContainer : IRuleContainer
    {
        private readonly Dictionary<Type, IRule> _container;

        private static Lazy<DefaultRuleContainer> _instance = new Lazy<DefaultRuleContainer>(() => new DefaultRuleContainer());

        public static DefaultRuleContainer Instance => _instance.Value;

        public DefaultRuleContainer()
        {
            _container = new Dictionary<Type, IRule>();
            AddRule<CreateTable>(new CreateTableRule());
        }

        public IRuleContainer AddRule<TQuery>(IRule rule) where TQuery : ISqlQuery
        {
            var queryType = typeof(TQuery);
            _container.Add(queryType, rule);
            return this;
        }

        public IRule GetRule<TQuery>() where TQuery : ISqlQuery
        {
            var queryType = typeof(TQuery);
            if (!_container.ContainsKey(queryType))
                throw new ArgumentOutOfRangeException($"Container does not contain query {queryType.Name}");

            return _container[queryType];

        }
    }
}