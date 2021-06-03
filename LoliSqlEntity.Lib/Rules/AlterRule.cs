namespace LoliSqlEntity.Lib.Rules
{
    public abstract class AlterRule : IRule
    {
        public string Prefix => $"ALTER"; 
        public abstract IRuleResult Execute(ISqlQuery sqlQuery);
    }
}