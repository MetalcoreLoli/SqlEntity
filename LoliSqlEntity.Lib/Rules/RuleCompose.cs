namespace LoliSqlEntity.Lib.Rules
{
    public static class RuleCompose
    {
        public static IRule And(this IRule a, IRule b)
            => new AndRule(a, b);
    }
}