using LoliSqlEntity.Lib.DDL.Table.Parameters;
using LoliSqlEntity.Lib.DML;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class UpdateTests
    {

        [Test]
        public void UpdateTest()
        {
            var query = new SqlQueryBuilder<UpdateQuery>()
                .AddParameter(new TableNameParameter("test"));
        }
    }
}