using LoliSqlEntity.Lib.DDL.Table.Parameters;
using LoliSqlEntity.Lib.DML;
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
                    .AddParameter(new ColumnParameter("TestOne"))
                    .AddParameter(new ValueParameter("1"))
                    .AddParameter(new ValueParameter("1"));
            
            Assert.AreEqual("INSERT INTO [dbo].[testTable] ([Test], [TestOne]) VALUES ('1', '1');\ngo\n", sqlBuilder.Construct());
        }

    }
}