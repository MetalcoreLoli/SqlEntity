using System;

namespace LoliSqlEntity.Lib.Table.Parameters
{
    public class DropColumnParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get => throw new MemberAccessException(); set => throw new MemberAccessException(); }
        public ISqlParameterType Type { get => throw new MemberAccessException(); set => throw new MemberAccessException(); }


        public DropColumnParameter(string name)
        {
            Name = name;
        }


        public override string ToString()
        {
            return $"DROP COLUMN [{Name}]";
        }
    }
}