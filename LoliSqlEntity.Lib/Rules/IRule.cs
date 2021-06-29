namespace LoliSqlEntity.Lib.Rules
{
    public interface IRule
    {
        string Prefix { get; }
        IRuleResult Execute(ISqlQuery sqlQuery);
    }
}