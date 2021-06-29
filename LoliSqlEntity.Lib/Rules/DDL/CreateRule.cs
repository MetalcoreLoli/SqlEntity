namespace LoliSqlEntity.Lib.Rules
{
    public abstract class CreateRule : IRule
    {
        public virtual string Prefix => "CREATE";
        public abstract IRuleResult Execute(ISqlQuery sqlQuery);
    }
}