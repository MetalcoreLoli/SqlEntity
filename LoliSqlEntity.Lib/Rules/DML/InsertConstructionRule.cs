using System;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.DML;
using LoliSqlEntity.Lib.Table.Parameters;

namespace LoliSqlEntity.Lib.Rules.DML
{
    public class InsertConstructionRule : IRule
    {
        public string Prefix => "INSERT CONSTRUCTION RULE"; 
        public IRuleResult Execute(ISqlQuery sqlQuery)
        {
            if (sqlQuery is not InsertQuery insertQuery)
                throw new ArgumentException("There is no insert query");

            var sb = new StringBuilder();

            if (insertQuery.Parameters.First() is not TableNameParameter table)
                throw new ArgumentException("first parameter must be table name");
            
            sb.Append($"{insertQuery.Name} INTO {table} (")
              .Append(
                insertQuery.Columns
                    .AsStringWithDelimiter(", ", p => $"[{p.Name}]"))
              .Append(") VALUES (")
              .Append(
                  insertQuery.Parameters.OfType<ValueParameter>()
                      .AsStringWithDelimiter(", ", p => $"'{p.Value}'"))
              .Append(")");

            return DefaultRuleResult.Wrap(sb.ToString());
        }
    }
}