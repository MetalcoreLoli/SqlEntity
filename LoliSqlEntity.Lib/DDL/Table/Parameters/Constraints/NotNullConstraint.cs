namespace LoliSqlEntity.Lib.DDL.Table.Parameters.Constraints
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