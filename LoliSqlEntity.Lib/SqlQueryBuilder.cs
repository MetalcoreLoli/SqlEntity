using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib
{
    
    public class SqlQueryBuilder<TSqlQuery>
        where TSqlQuery : ISqlQuery, new ()
    {
        private readonly TSqlQuery _query;
        private readonly IRuleContainer _container;

        public  SqlQueryBuilder(IRuleContainer container = null)
        {
            _query = new TSqlQuery();
            _container = container ?? new DefaultRuleContainer();
        }

        public SqlQueryBuilder<TSqlQuery> AddParameter(ISqlParameter parameter)
        {
            _query.Parameters.Add(parameter);
            return this;
        }
        
        public string Construct()
        {
            var sb = new StringBuilder();
            var queryAsString = _container.GetRule<TSqlQuery>().Execute(_query);
            return sb.Append(queryAsString).Append(";\ngo\n").ToString();
        }

    }
}