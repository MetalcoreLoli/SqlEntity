using System;
using System.Linq;
using System.Text;
using System.Threading;
using LoliSqlEntity.Lib.Table;
using LoliSqlEntity.Lib.Table.Parameters;

namespace LoliSqlEntity.Lib.Rules
{
    public sealed class CreateTableRule : CreateRule
    {
        public override string Execute(ISqlQuery sqlQuery)
        {
            if (sqlQuery is not CreateTable)
                throw new InvalidCastException("sqlQuery is not CREATE TABLE");

            var query = (CreateTable) sqlQuery;
            var sb = new StringBuilder();

            var tableName = query.Parameters.FirstOrDefault();
            if (tableName is not TableNameParameter)
                throw new ArgumentException("first parameter must be name of table");
            
            sb.Append("CREATE TABLE ").Append($"[{tableName.Name}].[{tableName.Value}]");

            if (query.Parameters.Count() < 2) 
                throw new Exception("cannot create empty table");

            sb.Append(' ').Append('(');
            var columns = query.Parameters.Skip(1).Aggregate("", (acc, param) => acc + param + ", ");

            sb
                .Append(
                    columns.SkipLast(2).Aggregate("", (acc, c) => acc + c))
                .Append(')');
            return sb.ToString();
        }
    }
}