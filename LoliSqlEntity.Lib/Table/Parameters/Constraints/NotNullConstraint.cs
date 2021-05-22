namespace LoliSqlEntity.Lib.Table.Parameters.Constraints
{
    public class NotNullConstraint : IColumnConstraint
    {
        public string Name => "NOT NULL";

        public override string ToString()
        {
            return Name;
        }
    }
}