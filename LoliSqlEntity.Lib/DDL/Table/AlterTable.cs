using System.Collections.Generic;

namespace LoliSqlEntity.Lib.DDL.Table
{
    public class AlterTable : ISqlQuery
    {
        public string Name { get; set; }
        public IList<ISqlParameter> Parameters { get; }


        public AlterTable()
        {
            Parameters = new List<ISqlParameter>();
        }
    }
}