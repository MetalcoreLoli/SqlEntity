using System;
using System.Collections.Generic;
using LoliSqlEntity.Lib.DDL.Table;
using LoliSqlEntity.Lib.DML;
using LoliSqlEntity.Lib.Rules.DDL;
using LoliSqlEntity.Lib.Rules.DML;

namespace LoliSqlEntity.Lib.Rules
{
    public class DefaultRuleContainer : IRuleContainer
    {
        private readonly Dictionary<Type, IRule> _container = new();

        private static Lazy<DefaultRuleContainer> _instance = new(() => new DefaultRuleContainer());

        public static DefaultRuleContainer Instance => _instance.Value;

        public DefaultRuleContainer()
        {
            AddRule<CreateTable>(new CreateTableRule());
            AddRule<AlterTable>(new AlterTableRule());
            AddRule<InsertQuery>(new InsertAddParamsRule().And(new InsertConstructionRule()));
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

        public IRuleContainer RemoveRule<TQuery>() where TQuery : ISqlQuery
        {
            var queryType = typeof(TQuery);
            if (!_container.ContainsKey(queryType))
                throw new ArgumentOutOfRangeException($"Container does not contain query {queryType.Name}");

            _container.Remove(queryType);
            return this;
        }

    }
}