using LoliSqlEntity.Lib.DDL.Table.Parameters.Constraints;

namespace LoliSqlEntity.Lib.DDL.Table.Parameters.Builders
{
    public class ColumnParameterBuilder
    {
        private readonly ColumnParameter _column;

        public ColumnParameterBuilder()
        {
            _column = new ColumnParameter();
        }

        public ColumnParameterBuilder Called(string name)
        {
            _column.Name = name;
            return this;
        }

        public ColumnParameterBuilder WithType(ISqlParameterType type)
        {
            _column.Type = type;
            return this;
        }

        public ColumnParameterBuilder Identity(uint seed = 1, uint increment = 1)
        {
            _column.Constraints.Add(new IdentityConstraint(seed, increment));
            return this;
        }

        public ColumnParameterBuilder NotNull()
        {
            _column.Constraints.Add(new NotNullConstraint());
            return this;
        }

        public ISqlParameter Build()
        {
            return _column;
        }
    }
}