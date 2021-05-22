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
            
            Assert.AreEqual("CREATE TABLE [dbo].[TestTable] ([Id] [INT]);\ngo\n", testTable);

        }
    }
}