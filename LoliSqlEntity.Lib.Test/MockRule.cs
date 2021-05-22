﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib.Test
{
    public class MockRule : IRule
    {
        public string Prefix => "MOCKRULE";

        public string Execute(ISqlQuery sqlQuery)
        {
            
            var sb = new StringBuilder();
            
            sb.Append(sqlQuery.ToString());
            
            // if query has any number of params 
            // this will concat them together
            if (sqlQuery.Parameters.Any())
            {
                var param = sqlQuery.Parameters.Aggregate(" ", (acc, param) => acc + param + ", ");
                sb.Append(
                    //take all chars except last 2 chars because they are ", "
                    param.Take(param.Length - 2).Aggregate("", (acc, c) => acc + c));
            }

            sb.Append(";\ngo\n");
            return sb.ToString();
        }
    }
    
    
    public class MockRuleContainer : IRuleContainer
    {
        private readonly Dictionary<string, IRule> _rules;
        
        public MockRuleContainer()
        {
            _rules = new Dictionary<string, IRule>();
        }

        public IRuleContainer AddRule<TQuery>(IRule rule)
            where TQuery : ISqlQuery
        {
            var queryName = typeof(TQuery).Name;
            
            if (!_rules.ContainsKey(queryName))
                _rules.Add(queryName, rule);
            
            return this;
        }

        public IRule GetRule<TQuery>() where TQuery : ISqlQuery
        {
            var queryName = typeof(TQuery).Name;
            return _rules[queryName];
        }
    }
}