namespace LoliSqlEntity.Lib.Test
{
    public class MockParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }

        public MockParameter(string value, ISqlParameterType type)
        {
            Name = "MOCKPARAM";
            Value = value;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name} = '{Value}'";
        }
    }
}