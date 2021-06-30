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
                    .WithTableName("testTable")
                    .WithColumn("Test")
                    .WithColumn("TestOne")
                    .AddParameter(new ValueParameter("1"))
                    .AddParameter(new ValueParameter("1"));
            
            Assert.AreEqual("INSERT INTO [dbo].[testTable] ([Test], [TestOne]) VALUES ('1', '1');\ngo\n", sqlBuilder.Construct());
        }
    }
}