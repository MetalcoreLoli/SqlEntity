namespace LoliSqlEntity.Lib.Rules
{
    public interface IRuleExecutionParams
    {
        object GetParameter();
        IRuleExecutionParams Add();
    }
}