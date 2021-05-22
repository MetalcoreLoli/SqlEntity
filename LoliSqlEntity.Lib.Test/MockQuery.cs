using System.Collections.Generic;

namespace LoliSqlEntity.Lib.Test
{
    public class MockQuery : ISqlQuery
    {
        public string Name { get; set; }
        public IList<ISqlParameter> Parameters { get; }
        public MockQuery()
        {
            Name = "MOCKQUERY";
            Parameters = new List<ISqlParameter>();
        }


        public override string ToString()
        {
            return Name;
        }
    }
}