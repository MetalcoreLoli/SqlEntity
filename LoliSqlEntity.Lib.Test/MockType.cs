using System;

namespace LoliSqlEntity.Lib.Test
{
    public class MockType : ISqlParameterType
    {
        public Type Type { get; set; }
        public string Value { get; set; }

        public MockType()
        {
            Value = "MOCKTYPE";
            Type = typeof(string);
        }
    }
}