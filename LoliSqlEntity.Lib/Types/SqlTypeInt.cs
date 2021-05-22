using System;

namespace LoliSqlEntity.Lib.Types
{
    public class SqlTypeInt : ISqlParameterType
    {
        public Type Type { get; set; }
        public string Value { get; set; }

        public SqlTypeInt()
        {
            Value = "int";
            Type = typeof(int);
        }


        public override string ToString()
        {
            return "[INT]";
        }
    }
}