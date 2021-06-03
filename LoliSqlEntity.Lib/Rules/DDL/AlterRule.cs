namespace LoliSqlEntity.Lib.Rules.DDL
{
    public abstract class AlterRule : IRule
    {
        public string Prefix => $"ALTER"; 
        public abstract IRuleResult Execute(ISqlQuery sqlQuery);
    }
}