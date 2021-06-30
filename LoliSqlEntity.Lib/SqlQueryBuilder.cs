using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.DDL.Table.Parameters;
using LoliSqlEntity.Lib.DDL.Table.Parameters.Constraints;
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
            _container = container ?? DefaultRuleContainer.Instance;
        }

        public SqlQueryBuilder<TSqlQuery> AddParameter(ISqlParameter parameter)
        {
            _query.Parameters.Add(parameter);
            return this;
        }

        public SqlQueryBuilder<TSqlQuery> WithTableName(string name) => 
            this.AddParameter(new TableNameParameter(name));

        public SqlQueryBuilder<TSqlQuery> WithColumn(string name) => 
            AddParameter(new ColumnParameter(name));

        public SqlQueryBuilder<TSqlQuery> WithColumn(string name, ISqlParameterType type) => 
            WithColumn(name, type, null);
        
        public SqlQueryBuilder<TSqlQuery> WithColumn(string name, ISqlParameterType type,
            IEnumerable<IColumnConstraint> constraints)
            => AddParameter(new ColumnParameter(name, type, constraints));

        public string Construct()
        {
            var sb = new StringBuilder();
            var queryAsString = _container.GetRule<TSqlQuery>().Execute(_query).ReturnAs<String>();
            return sb.Append(queryAsString).Append(";\ngo\n").ToString();
        }
    }
}