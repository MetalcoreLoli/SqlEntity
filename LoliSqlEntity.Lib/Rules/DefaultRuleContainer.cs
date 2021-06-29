using System;
using System.Collections.Generic;
using LoliSqlEntity.Lib.Table;

namespace LoliSqlEntity.Lib.Rules
{
    public class DefaultRuleContainer : IRuleContainer
    {
        private enum GuardType
        {
            TypeCheck
        }

        private readonly Dictionary<Type, IRule> _container;

        private static Lazy<DefaultRuleContainer> _instance = new Lazy<DefaultRuleContainer>(() => new DefaultRuleContainer());

        /// <summary>
        /// Guard expressions
        /// </summary>
        private static Dictionary<GuardType, Action<object>> _guards = new();
        public static DefaultRuleContainer Instance => _instance.Value;

        public DefaultRuleContainer()
        {
            _container = new Dictionary<Type, IRule>();
            AddRule<CreateTable>(new CreateTableRule());
            AddRule<AlterTable>(new AlterTableRule());
            
            _guards.Add(GuardType.TypeCheck, type =>
            {
                if (!_container.ContainsKey(type as Type))
                    throw new ArgumentOutOfRangeException($"Container does not contain query {(type as Type).Name}");
            });
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
            _guards[GuardType.TypeCheck](queryType);
            return _container[queryType];

        }

        public bool ContainsType(Type type)
        {
            return _container.ContainsKey(type);
        }

        public IRuleContainer RemoveRule<TQuery>() where TQuery : ISqlQuery
        {
            var queryType = typeof(TQuery);
            _guards[GuardType.TypeCheck](queryType);
            _container.Remove(queryType);
            return this;
        }
    }
}