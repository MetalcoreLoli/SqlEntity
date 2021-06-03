using LoliSqlEntity.Lib.Types;

namespace LoliSqlEntity.Lib.DDL.Table.Parameters
{
    public class ValueParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }

        public ValueParameter(string name, string value, ISqlParameterType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public ValueParameter(string value)
            : this("VALUE PARAMETER", value, new SqlTypeNvarchar(25))
        {
        }
    }
}