namespace LoliSqlEntity.Lib.Rules
{
    public interface IRule
    {
        string Prefix { get; }
        string Execute(ISqlQuery sqlQuery);
    }
}