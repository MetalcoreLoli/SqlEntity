using LoliSqlEntity.Lib.DDL.Table;
using LoliSqlEntity.Lib.DDL.Table.Parameters;
using LoliSqlEntity.Lib.Types;
using NUnit.Framework;

namespace LoliSqlEntity.Lib.Test
{
    public class AlterTableTests
    {

        [Test]
        public void AlterAddColumnTable()
        {
            var alterTable = 
                new SqlQueryBuilder<AlterTable>()
                    .WithTableName("TEST")
                    .WithColumn("testNvarchar", new SqlTypeNvarchar(25))
                    .Construct();

            Assert.AreEqual("ALTER TABLE [dbo].[TEST]\n\tADD COLUMN [testNvarchar] NVARCHAR (25);\ngo\n", alterTable);
        }
        
        [Test]
        public void AlterDropColumnTable()
        {
            var alterTable = 
                new SqlQueryBuilder<AlterTable>()
                    .WithTableName("TEST")
                    .AddParameter(new DropColumnParameter("testNvarchar"))
                    .Construct();

            Assert.AreEqual("ALTER TABLE [dbo].[TEST]\n\tDROP COLUMN [testNvarchar];\ngo\n", alterTable);
        }
        
        [Test]
        public void AlterColumnTable()
        {
            var alterTable = 
                new SqlQueryBuilder<AlterTable>()
                    .WithTableName("TEST")
                    .AddParameter(new AlterColumnParameter("testNvarchar", new SqlTypeNvarchar(25)))
                    .Construct();

            Assert.AreEqual("ALTER TABLE [dbo].[TEST]\n\tALTER COLUMN [testNvarchar] NVARCHAR (25);\ngo\n", alterTable);
        }
        
    }
}