using System;
using System.Collections.Generic;
using LoliSqlEntity.Lib.DDL.Table;
using LoliSqlEntity.Lib.DML;
using LoliSqlEntity.Lib.Guards;
using LoliSqlEntity.Lib.Rules.DDL;
using LoliSqlEntity.Lib.Rules.DML;

namespace LoliSqlEntity.Lib.Rules
{
    public class DefaultRuleContainer : IRuleContainer
    {
        private enum GuardState 
        {
            TypeChecking
        }
        
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
            var queryGuard = new QueryTypeGuard(this);
            var queryGuardConf = 
                new GuardConfiguration(queryGuard)
                    .PermitOn<TypeGuardArg>(queryType)
                    .Execute();
            return _container[queryType];

        }

        public bool ContainsType(Type type)
        {
            return _container.ContainsKey(type);
        }

        public IRuleContainer RemoveRule<TQuery>() where TQuery : ISqlQuery
        {
            var queryType = typeof(TQuery);
            var queryGuard = new QueryTypeGuard(this);
            var queryGuardConf = 
                new GuardConfiguration(queryGuard)
                    .PermitOn<TypeGuardArg>(queryType)
                    .Execute();
            
            _container.Remove(queryType);
            return this;
        }

    }
}