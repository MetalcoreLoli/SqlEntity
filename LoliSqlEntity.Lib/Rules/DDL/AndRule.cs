namespace LoliSqlEntity.Lib.Rules
{
    public class AndRule : IRule
    {
        private readonly IRule _rhs;
        private readonly IRule _lhs;
        public string Prefix => "AND";

        public AndRule(IRule right, IRule left)
        {
            _rhs = right;
            _lhs = left;
        }

        public IRuleResult Execute(ISqlQuery sqlQuery)
        {
            _rhs.Execute(sqlQuery);
            return _lhs.Execute(sqlQuery);
        }
    }
}