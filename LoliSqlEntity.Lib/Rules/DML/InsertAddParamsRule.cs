using System;
using System.Linq;
using LoliSqlEntity.Lib.DDL.Table.Parameters;
using LoliSqlEntity.Lib.DML;

namespace LoliSqlEntity.Lib.Rules.DML
{
    public class InsertAddParamsRule : IRule
    {
        public string Prefix => "INSERT PARAMS RULE"; 
        public IRuleResult Execute(ISqlQuery sqlQuery)
        {
            if (sqlQuery is not InsertQuery insertQuery)
                throw new ArgumentException("query is not insert query!!!");
            
            foreach (var column in sqlQuery.Parameters.OfType<ColumnParameter>())
                insertQuery.Columns.Add(column);

            return DefaultRuleResult.Wrap(Prefix);
        }
    }
}