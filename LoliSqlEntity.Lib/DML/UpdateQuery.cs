using System.Collections.Generic;
using LoliSqlEntity.Lib.DDL.Table.Parameters;

namespace LoliSqlEntity.Lib.DML
{
    public class UpdateQuery : ISqlQuery
    {
        public UpdateQuery(TableNameParameter tableName, IList<ISqlParameter> parameters)
        {
            Name = "UPDATE";
            TableName = tableName;
            Parameters = parameters;
        }

        public UpdateQuery()
        {
            Name = "UPDATE";
        }

        public string Name { get; set; }
        public  TableNameParameter TableName { get; }
        public IList<ISqlParameter> Parameters { get; }
    }
}