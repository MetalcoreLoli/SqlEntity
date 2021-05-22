namespace LoliSqlEntity.Lib.Table.Parameters
{
    public class TableNameParameter : ISqlParameter
    {
        /// <summary>
        /// name of scheme
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// name of table
        /// </summary>
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }


        public TableNameParameter(string value)
            : this ("dbo", value)
        {
        }

        public TableNameParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"[{Name}].[{Value}]";
        }
    }
}