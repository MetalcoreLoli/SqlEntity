using System;

namespace LoliSqlEntity.Lib
{
    public interface ISqlParameter
    {
        string Name { get; set; }
        string Value { get; set; }
        ISqlParameterType Type { get; set; }
    }

    public interface ISqlParameterType
    {
        Type Type { get; set; }
        string Value { get; set; }
    }
}