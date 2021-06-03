using System.Collections.Generic;

namespace LoliSqlEntity.Lib.DML
{
    public class InsertQuery : ISqlQuery
    {
        /// <summary>
        /// Name of table
        /// </summary>
        public string Name { get; set; }
        public IList<ISqlParameter> Columns { get; }
        public IList<ISqlParameter> Parameters { get; }


        public InsertQuery(IList<ISqlParameter> columns, IList<ISqlParameter> parameters)
        {
            Name = "INSERT";
            Columns = columns;
            Parameters = parameters;
        }

        public InsertQuery()
            : this ( new List<ISqlParameter>(), new List<ISqlParameter>())
        {
        }
    }
}