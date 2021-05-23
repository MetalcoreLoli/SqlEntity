using LoliSqlEntity.Lib.Table;
using LoliSqlEntity.Lib.Table.Parameters;
using LoliSqlEntity.Lib.Types;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class AlterTableTests
    {

        [Test]
        public void AlterTable()
        {
            var alterTable = 
                new SqlQueryBuilder<AlterTable>()
                    .AddParameter(new TableNameParameter("TEST"))
                    .AddParameter(new ColumnParameter("testNvarchar", new SqlTypeNvarchar(25)))
                    .Construct();

            Assert.AreEqual("ALTER TABLE [dbo].[TEST]\n\tADD COLUMN [testNvarchar] NVARCHAR (25);\ngo\n", alterTable);
        }
    }
}