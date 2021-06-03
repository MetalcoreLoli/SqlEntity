using LoliSqlEntity.Lib.DML;
using LoliSqlEntity.Lib.Table.Parameters;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class InsertQueryTests
    {

        [Test]
        public void InsertTest()
        {
            var sqlBuilder = 
                new SqlQueryBuilder<InsertQuery>()
                    .AddParameter(new TableNameParameter("testTable"))
                    .AddParameter(new ColumnParameter("Test"))
                    .AddParameter(new ColumnParameter("Test"));
        }

    }
}