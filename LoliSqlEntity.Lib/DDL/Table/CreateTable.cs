using System;
using System.Collections.Generic;
using System.Linq;
using LoliSqlEntity.Lib.DDL.Table.Parameters;

namespace LoliSqlEntity.Lib.DDL.Table
{
    public class CreateTable : ISqlQuery
    {
        public string Name { get; set; }
        public IList<ISqlParameter> Parameters { get; }

        public CreateTable()
        {
            Parameters = new List<ISqlParameter>();
        }

        public override string ToString()
        {
            var nameOfTable = Parameters.FirstOrDefault();
            if (nameOfTable == null || !(nameOfTable is TableNameParameter))
                throw new ArithmeticException($"{nameof(TableNameParameter)} must be the first parameter !!!");
            
            return $"CREATE TABLE {Parameters.First()}";
        }
    }
}