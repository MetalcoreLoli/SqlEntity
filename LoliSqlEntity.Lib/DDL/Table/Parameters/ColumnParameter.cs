using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoliSqlEntity.Lib.DDL.Table.Parameters.Builders;
using LoliSqlEntity.Lib.DDL.Table.Parameters.Constraints;
using LoliSqlEntity.Lib.Types;

namespace LoliSqlEntity.Lib.DDL.Table.Parameters
{
    public class ColumnParameter : ISqlParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ISqlParameterType Type { get; set; }
        
        public List<IColumnConstraint> Constraints { get; }

        public ColumnParameter(): this(string.Empty, null)
        {
        }

        public ColumnParameter(string name) : this(name, new SqlTypeNvarchar(25))
        {
            
        }


        public ColumnParameter(string name, ISqlParameterType type) : this(name, type, new List<IColumnConstraint>())
        {
        }

        public ColumnParameter(string name, ISqlParameterType type, IEnumerable<IColumnConstraint> constraints)
        {
            Name = name;
            Type = type;
            Constraints = constraints.ToList();
        }

        public static ColumnParameterBuilder New(string name, ISqlParameterType type)
        {
            var builder = new ColumnParameterBuilder().Called(name).WithType(type);
            return builder;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"[{Name}] {Type}");
            if (Constraints.Any())
            {
                var constraints = Constraints.Aggregate(" ", (acc, constraint) => acc + constraint + " ");
                constraints = constraints.SkipLast(1).Aggregate("", (acc, c) => acc + c);
                sb.Append(constraints);
            }
                
            return sb.ToString();
        }
    }
}