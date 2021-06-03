namespace LoliSqlEntity.Lib.Rules
{
    public class DefaultRuleResult : IRuleResult
    {
        private readonly object _value;

        public DefaultRuleResult(object value)
        {
            _value = value;
        }

        public static DefaultRuleResult Wrap(object value) => new(value);
        public static TResult UnwrapAs<TResult>(DefaultRuleResult result) => result.ReturnAs<TResult>();
        public TResult ReturnAs<TResult>() => (TResult) _value;
    }
}