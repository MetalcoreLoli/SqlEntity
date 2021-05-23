using System;

namespace LoliSqlEntity.Lib.Types
{
    public class SqlTypeNvarchar : ISqlParameterType
    {
        public Type     Type    { get; set; }
        public string   Value   { get; set; }
        public uint     Lenght  { get; set; }


        public SqlTypeNvarchar(uint lenght)
        {
            Type = typeof(string);
            Value = "NVARCHAR";
            Lenght = lenght;
        }

        public override string ToString() => $"{Value} ({Lenght})";
    }
}