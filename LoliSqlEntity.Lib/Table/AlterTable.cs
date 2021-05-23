using System.Collections.Generic;
using LoliSqlEntity.Lib.Rules;

namespace LoliSqlEntity.Lib.Table
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