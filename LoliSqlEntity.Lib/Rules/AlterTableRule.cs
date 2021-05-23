using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.Table;
using LoliSqlEntity.Lib.Table.Parameters;

namespace LoliSqlEntity.Lib.Rules
{
    public class AlterTableRule :  AlterRule
    {
        private readonly Dictionary<Type, string> actions;

        public AlterTableRule()
        {
            actions = new Dictionary<Type, string>
            {
                {typeof(ColumnParameter), "ADD COLUMN"}
            };
        }

        public override string Execute(ISqlQuery sqlQuery)
        {
            if (sqlQuery is not AlterTable)
                throw new ArgumentOutOfRangeException("sqlQuery is not ALTER TABLE");

            var sb = new StringBuilder();

            var tableName = sqlQuery.Parameters.FirstOrDefault();
            if (tableName is not TableNameParameter)
                throw new ArgumentNullException("first parameter must be table name !!!");
            
            sb.Append($"{Prefix} TABLE [{tableName.Name}].[{tableName.Value}]\n\t");

            foreach (var param in sqlQuery.Parameters.Skip(1))
                sb.Append($"{actions[param.GetType()]} {param}");
            
            return sb.ToString();
        }
    }
}