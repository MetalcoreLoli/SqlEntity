namespace LoliSqlEntity.Lib.Table.Parameters
{
    public class ColumnParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }

        public ColumnParameter(string name, ISqlParameterType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"[{Name}] {Type}";
        }
    }
}