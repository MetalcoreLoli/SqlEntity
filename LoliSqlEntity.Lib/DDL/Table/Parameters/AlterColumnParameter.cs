namespace LoliSqlEntity.Lib.DDL.Table.Parameters
{
    public class AlterColumnParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }

        public AlterColumnParameter(string name, ISqlParameterType type)
        {
            Name = name;
            Type = type;
        }


        public override string ToString()
        {
            return $"ALTER COLUMN [{Name}] {Type}";
        }
    }
}