using LoliSqlEntity.Lib.Table;
using LoliSqlEntity.Lib.Table.Parameters;
using LoliSqlEntity.Lib.Types;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class CreateTableTests
    {
        [Test]
        public void CreateTable()
        {
            var testTable =
                new SqlQueryBuilder<CreateTable>()
                    .AddParameter(new TableNameParameter("TestTable"))
                    .AddParameter(new ColumnParameter("Id", new SqlTypeInt()))
                    .Construct();
            
            Assert.AreEqual("CREATE TABLE [dbo].[TestTable] ([Id] INT);\ngo\n", testTable);

        }


        [Test]
        public void CreateColumnTest()
        {
            var test =
                new SqlQueryBuilder<CreateTable>()
                    .AddParameter(new TableNameParameter("TestColumn"))
                    .AddParameter(ColumnParameter.New("Id", new SqlTypeInt()).Identity().NotNull().Build())
                    .Construct();
            
            Assert.AreEqual("CREATE TABLE [dbo].[TestColumn] ([Id] INT IDENTITY (1, 1) NOT NULL);\ngo\n", test);
        }
    }
}