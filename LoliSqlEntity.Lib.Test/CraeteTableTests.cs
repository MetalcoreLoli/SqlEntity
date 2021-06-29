using LoliSqlEntity.Lib.DDL.Table;
using LoliSqlEntity.Lib.DDL.Table.Parameters;
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
            
            Assert.AreEqual("CREATE TABLE [dbo].[TestTable] (\n[Id] INT\n);\ngo\n", testTable);
        }


        [Test]
        public void CreateColumnTest()
        {
            var test =
                new SqlQueryBuilder<CreateTable>()
                    .AddParameter(new TableNameParameter("TestColumn"))
                    .AddParameter(ColumnParameter.New("Id", new SqlTypeInt()).Identity().NotNull().Build())
                    .AddParameter(ColumnParameter.New("Name", new SqlTypeNvarchar(25)).NotNull().Build())
                    .Construct();
            
            Assert.AreEqual("CREATE TABLE [dbo].[TestColumn] (\n[Id] INT IDENTITY (1, 1) NOT NULL,\n\t[Name] NVARCHAR (25) NOT NULL\n);\ngo\n", test);
        }
    }
}