using System;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.DDL.Table;
using LoliSqlEntity.Lib.DDL.Table.Parameters;

namespace LoliSqlEntity.Lib.Rules.DDL
{
    public sealed class CreateTableRule : CreateRule
    {
        public override IRuleResult Execute(ISqlQuery sqlQuery)
        {
            if (sqlQuery is not CreateTable)
                throw new InvalidCastException("sqlQuery is not CREATE TABLE");

            var query = (CreateTable) sqlQuery;
            var sb = new StringBuilder();

            var tableName = query.Parameters.FirstOrDefault();
            if (tableName is not TableNameParameter)
                throw new ArgumentException("first parameter must be name of table");
            
            sb.Append($"{Prefix} TABLE ").Append($"[{tableName.Name}].[{tableName.Value}]");

            if (query.Parameters.Count < 2) 
                throw new Exception("cannot create empty table");

            sb.Append(' ').Append("(\n");
            var columns = query.Parameters.Skip(1).Aggregate("", (acc, param) => acc + param + ",\n\t");

            sb.Append(
                    columns.SkipLast(3).Aggregate("", (acc, c) => acc + c))
              .Append("\n)");
            return DefaultRuleResult.Wrap(sb.ToString());
        }
    }
}